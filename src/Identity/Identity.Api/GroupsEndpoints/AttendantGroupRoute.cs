namespace Identity.Api.GroupsEndpoints;

public static class AttendantGroupRoute
{
    public static RouteGroupBuilder AddAttendantGroupRoute(this RouteGroupBuilder group)
    {
        group.WithTags("AttendantsEndpoints");
        GetAllAttendants(group);
        CreateAttendant(group);
        DeleteAttendant(group);
        UpdateAttendant(group);
        GetAttendantById(group);

        return group;
    }

    private static RouteHandlerBuilder GetAttendantById(RouteGroupBuilder group)
    {
        return
            group.MapPost("GetAttendantById/{id}",
            [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)] async (
                [FromServices] IAttendantService _service,
                [FromRoute] Guid id,
                CancellationToken cancellationToken) =>
            {
                return await _service.GetAttendantByIdAsync(new GetAttendantByIdRequest { Id = id }, cancellationToken);
            })
            .WithDescription("Get attendant by id")
            .WithSummary("Get attendant by id");
    }

    private static RouteHandlerBuilder UpdateAttendant(RouteGroupBuilder group)
    {
        return group.MapPatch("UpdateAttendants",
            [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)] async (
                [FromServices] IAttendantService _service,
                [FromBody] UpdateAttendantRequest request,
                CancellationToken cancellationToken) =>
            {
                return await _service.UpdateAttendantAsync(request, cancellationToken);
            })
            .WithDescription("Update attendants")
            .WithSummary("Update attendants");
    }

    private static RouteHandlerBuilder DeleteAttendant(RouteGroupBuilder group)
    {
        return group.MapDelete("DeleteAttendants/{id}",
            [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)] async (
                [FromServices] IAttendantService _service,
                [FromRoute] Guid id,
                CancellationToken cancellationToken) =>
            {
                return await _service.DeleteAttendantAsync(new DeleteAttendantRequest { Id = id }, cancellationToken);
            })
            .WithSummary("Delete attendants")
            .WithDescription("Delete attendants");
    }

    private static RouteHandlerBuilder CreateAttendant(RouteGroupBuilder group)
    {
        return group.MapPost("CreateAttendants",
            [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] IAttendantService _service,
        [FromBody] CreateAttendantRequest request,
        CancellationToken cancellationToken) =>
            {
                return await _service.CreateAttendantAsync(request, cancellationToken);
            })
            .WithSummary("Create attendants")
            .WithDescription("Create attendants");
    }

    private static RouteHandlerBuilder GetAllAttendants(RouteGroupBuilder group)
    {
        return group.MapGet("GetAllAttendants",
            [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async ([FromServices] IAttendantService _service, CancellationToken cancellationToken) =>
            {
                return await _service.GetAllAttendantAsync(new(), default);
            })
            .WithDescription("Get all attendants")
            .WithSummary("Get all attendants")
            .Produces(200, typeof(GetAllAttendantResponse));
    }
}

