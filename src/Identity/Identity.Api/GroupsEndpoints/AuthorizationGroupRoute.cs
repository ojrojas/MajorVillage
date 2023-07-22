namespace Identity.Api.GroupsEndpoints;

public static class AuthorizationGroupRoute
{
    public static RouteGroupBuilder AddAuthorizationGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("/connect/token", [IgnoreAntiforgeryToken]
        async (HttpContext _context,
        IOpenIddictApplicationManager _applicationManager,
        IOpenIddictScopeManager _scopeManager,
        IUserApplicationService _applicationService) =>
        {
            var request = _context.GetOpenIddictServerRequest() ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");

            if (request.IsClientCredentialsGrantType())
                return await CreateSignInLogin(_applicationManager, _scopeManager, request);

            if (request.IsAuthorizationCodeGrantType())
            {
                var authentication = await _context.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                return await CreateSignInLogin(_applicationManager, _scopeManager, request, authentication);
            }

            if (request.IsPasswordGrantType())
            {
                ArgumentNullException.ThrowIfNull(request.ClientId, "Not found clientId request");
                ArgumentNullException.ThrowIfNull(request.Username, "Not found username request");
                ArgumentNullException.ThrowIfNull(request.Password, "Not found password request");

                var response = await _applicationService.LoginAsync(
                    new()
                    {
                        ClientId = request.ClientId,
                        UserName = request.Username,
                        Password = request.Password,
                        Scopes = request.GetScopes()
                    }, default);

                return response;
            }

            throw new NotImplementedException("the specified request is no a open iddict request implemented");
        });

        group.MapMethods("/connect/authorize", new[] { HttpMethods.Post, HttpMethods.Get },
            async (
                HttpContext _context,
                IOpenIddictApplicationManager _applicationManager,
                IOpenIddictScopeManager _scopeManager) =>
            {
                var request = _context.GetOpenIddictServerRequest() ?? throw new ArgumentNullException("context_request","not found request valid");
                ArgumentNullException.ThrowIfNull(request.ClientId);

                var typeAuthorization = request.GrantType;

                var result = await _context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                if (result is not { Succeeded: true })
                {
                    var url = _context.Request.PathBase + _context.Request.Path + QueryString.Create(
                        _context.Request.HasFormContentType ? _context.Request.Form.ToList() : _context.Request.Query.ToList());

                    return Results.Challenge(properties: new AuthenticationProperties
                    {
                        RedirectUri = url
                    }, new List<string> { CookieAuthenticationDefaults.AuthenticationScheme }
                    );
                }

                var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
                throw new InvalidOperationException("the application details cannot be found into database");

                var identity = new ClaimsIdentity(
               authenticationType: TokenValidationParameters.DefaultAuthenticationType,
               nameType: Claims.Name,
               roleType: Claims.Role);

                // Add the claims that will be persisted in the tokens (use the client_id as the subject identifier).
                identity.SetClaim(Claims.Subject, await _applicationManager.GetClientIdAsync(application));
                identity.SetClaim(Claims.Name, await _applicationManager.GetDisplayNameAsync(application));

                identity.SetScopes(request.GetScopes());
                identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());
                identity.SetDestinations(GetDestination.GetDestinations);

                return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            });

        return group;
    }

    private static async ValueTask<IResult> CreateSignInLogin(
        IOpenIddictApplicationManager _applicationManager,
        IOpenIddictScopeManager _scopeManager,
        OpenIddictRequest request,
        AuthenticateResult? authentication = null)
    {
        ArgumentNullException.ThrowIfNull(request.ClientId, "Error request not found");

        var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
            throw new InvalidOperationException("the application details cannot be found in the database");

        ClaimsIdentity identity;

        if (authentication is not null)
            identity = new ClaimsIdentity(
                authentication?.Principal?.Claims,
                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                nameType: Claims.Name,
                roleType: Claims.Role);
        else identity = new ClaimsIdentity(
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);

        // Add the claims that will be persisted in the tokens (use the client_id as the subject identifier).
        identity.SetClaim(Claims.Subject, await _applicationManager.GetClientIdAsync(application));
        identity.SetClaim(Claims.Name, await _applicationManager.GetDisplayNameAsync(application));

        identity.SetScopes(request.GetScopes());
        identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());
        identity.SetDestinations(GetDestination.GetDestinations);

        return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}