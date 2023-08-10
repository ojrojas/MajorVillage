namespace Identity.Api.GroupsEndpoints;

public static class UserApplicationGroupRoute
{
    public static RouteGroupBuilder AddUserApplicationGroupRoute(this RouteGroupBuilder group)
    {
        group.WithTags("UserApplicationEndpoints");
        GetAllUsers(group);
        GetUserById(group);
        CreateUserApplication(group);
        DeleteUserApplication(group);
        UpdateUserApplication(group);

        return group;
    }

    private static RouteHandlerBuilder UpdateUserApplication(RouteGroupBuilder group)
    {
        return group.MapPatch("UpdateUserApplication", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] IUserApplicationService _service, UpdateUserApplicationRequest request, CancellationToken cancellationToken) =>
        {
            return await _service.UpdateUserApplicationAsync(request, cancellationToken);
        });
    }

    private static RouteHandlerBuilder DeleteUserApplication(RouteGroupBuilder group)
    {
        return group.MapDelete("DeleteUserApplication/{Id}", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] IUserApplicationService _service, [FromRoute] Guid Id, CancellationToken cancellationToken) =>
        {
            return await _service.DeleteUserApplicationAsync(new DeleteUserApplicationRequest { Id = Id }, cancellationToken);
        });
    }

    private static RouteHandlerBuilder CreateUserApplication(RouteGroupBuilder group)
    {
        return group.MapPost("CreateUserApplication", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] IUserApplicationService _service, CreateUserApplicationRequest request, CancellationToken cancellationToken) =>
        {
            return await _service.CreateUserApplicationAsync(request, cancellationToken);
        });
    }

    private static RouteHandlerBuilder GetUserById(RouteGroupBuilder group)
    {
        return group.MapGet("GetUserById/{Id}", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] IUserApplicationService _service, [FromRoute] Guid Id, CancellationToken cancellationToken) =>
        {
            return await _service.GetUserByIdAsync(new GetUserByIdRequest { Id = Id }, cancellationToken);
        });
    }

    private static RouteHandlerBuilder GetAllUsers(RouteGroupBuilder group)
    {
        return group.MapGet("GetAllUsers", [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] IUserApplicationService _service, CancellationToken cancellationToken) =>
        {
            return await _service.GetAllUserApplicationsAsync(new(), cancellationToken);
        });
    }
}