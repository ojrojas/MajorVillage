namespace Identity.Api.GroupsEndpoints;

public static class TypeUserGroupRoute
{
    public static RouteGroupBuilder AddTypeUserGroupRoute(this RouteGroupBuilder group)
    {
        group.WithTags("TypeUserEndponts");

        group.MapGet("GetAllTypeUser", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeUserService _service, CancellationToken cancellationToken) =>
        {
            return await _service.GetAllTypeUserAsync(new(), cancellationToken);
        });
        return group;
    }
}

