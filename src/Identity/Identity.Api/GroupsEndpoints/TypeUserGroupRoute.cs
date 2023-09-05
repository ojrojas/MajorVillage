namespace Identity.Api.GroupsEndpoints;

public static class TypeUserGroupRoute
{
    public static RouteGroupBuilder AddTypeUserGroupRoute(this RouteGroupBuilder group)
    {
        group.WithTags("TypeUserEndpoints");
        GetAllTypeUser(group);
        CreateTypeUser(group);
        GetTypeUserById(group);
        DeleteTypeUser(group);
        UpdateTypeUser(group);

        return group;
    }

    private static RouteHandlerBuilder UpdateTypeUser(RouteGroupBuilder group)
    {
        return
                group.MapPatch("UpdateTypeUser", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeUserService _service, UpdateTypeUserRequest request, CancellationToken cancellationToken) =>
                {
                    return await _service.UpdateTypeUserAsync(request, cancellationToken);
                });
    }

    private static RouteHandlerBuilder DeleteTypeUser(RouteGroupBuilder group)
    {
        return
                group.MapDelete("DeleteTypeUser/{Id}", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeUserService _service, Guid Id, CancellationToken cancellationToken) =>
                {
                    return await _service.DeleteTypeUserAsync(new DeleteTypeUserRequest { Id = Id }, cancellationToken);
                });
    }

    private static RouteHandlerBuilder GetTypeUserById(RouteGroupBuilder group)
    {
        return
                group.MapGet("GetTypeUserById/{Id}", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeUserService _service, Guid Id, CancellationToken cancellationToken) =>
                {
                    return await _service.GetTypeUserByIdAsync(new GetTypeUserByIdRequest { Id = Id }, cancellationToken);
                });
    }

    private static RouteHandlerBuilder CreateTypeUser(RouteGroupBuilder group)
    {
        return
                group.MapPost("CreateTypeUser", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeUserService _service, CreateTypeUserRequest request, CancellationToken cancellationToken) =>
                {
                    return await _service.CreateTypeUserAsync(request, cancellationToken);
                }).WithDescription("Create type user")
                .WithSummary("Create type user");
    }

    private static RouteHandlerBuilder GetAllTypeUser(RouteGroupBuilder group)
    {
        return
                group.MapGet("GetAllTypeUser", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] ITypeUserService _service, CancellationToken cancellationToken) =>
                {
                    return await _service.GetAllTypeUserAsync(new(), cancellationToken);
                }).WithDescription("Get all type users")
                .WithSummary("Get all type users");
    }
}

