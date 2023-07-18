namespace Identity.Api.GroupsEndpoints;

public static class AttendantGroupRoute
{
    public static RouteGroupBuilder AddAttendantGroupRoute(this RouteGroupBuilder group)
    {
        group.WithTags("Attendants");

        group.MapGet("GetAllAttendants",
            [Authorize] async (
                [FromServices] IAttendantService _service, CancellationToken cancellationToken) =>
            {
                return await _service.GetAllAttendantAsync(new(), default);
            })
            .WithDescription("Get all attendants")
            .WithSummary("Get all attendants");

        group.MapPost("CreateAttendants",
            [Authorize] async ([FromServices] IAttendantService _service,
            [FromBody] CreateAttendantRequest request,
            CancellationToken cancellationToken) =>
            {
                return await _service.CreateAttendantAsync(request, cancellationToken);
            })
            .WithSummary("Create attendants")
            .WithDescription("Create attendants");


        group.MapDelete("DeleteAttendants/{id}",
            [Authorize] async (
                [FromServices] IAttendantService _service,
                [FromRoute] Guid id,
                CancellationToken cancellationToken) =>
            {
                return await _service.DeleteAttendantAsync(new DeleteAttendantRequest { Id = id }, cancellationToken);
            })
            .WithSummary("Delete attendants")
            .WithDescription("Delete attendants");

        group.MapPatch("UpdateAttendants",
            [Authorize] async (
                [FromServices] IAttendantService _service,
                [FromBody] UpdateAttendantRequest request,
                CancellationToken cancellationToken) =>
            {
                return await _service.UpdateAttendantAsync(request, cancellationToken);
            })
            .WithDescription("Update attendants")
            .WithSummary("Update attendants");

        group.MapPost("GetAttendantById/{id}",
            [Authorize] async (
                [FromServices] IAttendantService _service,
                [FromRoute] Guid id,
                CancellationToken cancellationToken) =>
            {
                return await _service.GetAttendantByIdAsync(new GetAttendantByIdRequest { Id = id }, cancellationToken);
            })
            .WithDescription("Get attendant by id")
            .WithSummary("Get attendant by id");

        return group;
    }
}

