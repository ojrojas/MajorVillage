namespace Identity.Core.Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly UserApplicationRepository _repository;
    private readonly ILoggerApplicationService<UserApplicationService> _logger;
    private readonly UserManager<UserApplication> _userManager;
    private readonly IOpenIddictApplicationManager _applicationManager;
    private readonly IOpenIddictAuthorizationManager _authorizationManager;
    private readonly IOpenIddictScopeManager _scopeManager;

    private readonly IPasswordHasher<UserApplication> _passwordHasher = new PasswordHasher<UserApplication>();

    public UserApplicationService(UserApplicationRepository repository,
                                  ILoggerApplicationService<UserApplicationService> logger,
                                  IOpenIddictApplicationManager applicationManager,
                                  IOpenIddictScopeManager scopeManager,
                                  IOpenIddictAuthorizationManager authorizationManager,
                                  UserManager<UserApplication> userManager)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _applicationManager = applicationManager ?? throw new ArgumentNullException(nameof(applicationManager));
        _scopeManager = scopeManager ?? throw new ArgumentNullException(nameof(scopeManager));
        _authorizationManager = authorizationManager ?? throw new ArgumentNullException(nameof(authorizationManager));
    }

    public async ValueTask<CreateUserApplicationResponse> CreateUserApplicationAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken)
    {
        CreateUserApplicationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create user application request");
        if (request.UserApplication is null) throw new ArgumentNullException(nameof(request.UserApplication));
        ArgumentNullException.ThrowIfNull(request.UserApplication.PasswordHash);
        ArgumentNullException.ThrowIfNull(request.UserApplication.UserName);
        request.UserApplication.UserName = request.UserApplication.UserName.ToLowerInvariant();
        request.UserApplication.PasswordHash = _passwordHasher.HashPassword(request.UserApplication, request.UserApplication.PasswordHash);
        _logger.LogInformation($"Create user application {JsonSerializer.Serialize(request.UserApplication)}");
        var created = await _repository.CreateAsync(request.UserApplication, cancellationToken);
        response.UserApplicationCreated = created is not null;
        return response;
    }

    public async ValueTask<DeleteUserApplicationResponse> DeleteUserApplicationAsync(DeleteUserApplicationRequest request, CancellationToken cancellationToken)
    {
        DeleteUserApplicationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete userapplication request");
        if (request.Id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(request.Id));
        UserApplication userApplication = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.UserApplicationDeleted = await _repository.DeleteAsync(userApplication, cancellationToken);
        return response;
    }

    public async ValueTask<GetAllUserApplicationResponse> GetAllUserApplicationsAsync(GetAllUserApplicationRequest request, CancellationToken cancellationToken)
    {
        GetAllUserApplicationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all user applications request");
        response.UserApplications = await _repository.ListAsync(cancellationToken);
        if(response is not null && response.UserApplications.Any())
        {
            foreach(var user in response.UserApplications)
            {
                user.PasswordHash = "Private Field";
                user.ConcurrencyStamp = "Private Field";
                user.SecurityStamp = "Private Field";
            }
        }

        return response;
    }

    public async ValueTask<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        GetUserByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get user by  applications request");
        response.UserApplication = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.UserApplication.PasswordHash = string.Empty;
        response.UserApplication.SecurityStamp = string.Empty;
        response.UserApplication.ConcurrencyStamp = string.Empty;
        return response;
    }

    public async ValueTask<UpdateUserApplicationResponse> UpdateUserApplicationAsync(UpdateUserApplicationRequest request, CancellationToken cancellationToken)
    {
        UpdateUserApplicationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Update user application request");
        response.UserApplication = await _repository.UpdateAsync(request.UserApplication, cancellationToken);
        return response;
    }

    public async ValueTask<IResult> LoginAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken)
    {
        LoginUserApplicationResponse response = new(request.CorrelationId())
        {
            Token = "Do not get token response"
        };

        _logger.LogInformation(response, "Encrypt password and get user by login");

        request.UserName = request.UserName.ToLowerInvariant();
        UserApplicationSpecifications specification = new(request.UserName);
        var result = await _repository.FirstOrDefaultAsync(specification, cancellationToken);

        if (result is not null)
        {
            var token = await _userManager.CheckPasswordAsync(result, request.Password);
            if (token)
            {
                // Retrieve the application details from the database.
                var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
                    throw new InvalidOperationException("Details concerning the calling client application cannot be found.");

                // Retrieve the permanent authorizations associated with the user and the calling client application.
                var authorizations = await _authorizationManager.FindAsync(
                    subject: await _userManager.GetUserIdAsync(result),
                    client: await _applicationManager.GetIdAsync(application, cancellationToken),
                    status: Statuses.Valid,
                    type: AuthorizationTypes.Permanent,
                    scopes: request.Scopes.ToImmutableArray(),
                    cancellationToken).ToListExtensionsAsync();

                // Create the claims-based identity that will be used by OpenIddict to generate tokens.
                var identity = new ClaimsIdentity(
                    authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                    nameType: Claims.Name,
                    roleType: Claims.Role);

                // Add the claims that will be persisted in the tokens.
                identity.SetClaim(Claims.Subject, await _userManager.GetUserIdAsync(result))
                        .SetClaim(Claims.Email, await _userManager.GetEmailAsync(result))
                        .SetClaim(Claims.Name, await _userManager.GetUserNameAsync(result))
                        .SetClaims(Claims.Role, (await _userManager.GetRolesAsync(result)).ToImmutableArray());

                // Note: in this sample, the granted scopes match the requested scope
                // but you may want to allow the user to uncheck specific scopes.
                // For that, simply restrict the list of scopes before calling SetScopes.
                identity.SetScopes(request.Scopes);
                identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListExtensionsAsync());

                // Automatically create a permanent authorization to avoid requiring explicit consent
                // for future authorization or token requests containing the same scopes.
                var authorization = authorizations.LastOrDefault();
                authorization ??= await _authorizationManager.CreateAsync(
                    identity: identity,
                    subject: await _userManager.GetUserIdAsync(result),
                    client: await _applicationManager.GetIdAsync(application),
                    type: AuthorizationTypes.Permanent,
                    scopes: identity.GetScopes());

                identity.SetAuthorizationId(await _authorizationManager.GetIdAsync(authorization));
                identity.SetDestinations(GetDestination.GetDestinations);

                // Returning a SignInResult will ask OpenIddict to issue the appropriate access/identity tokens.
                response.ActionResult = Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                response.Token = "Signin successful";
            }
        }

        return response.ActionResult;
    }
}