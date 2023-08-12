namespace Aggregator.Web.Api.Endpoints;

public static class ClassRoomGroupRoute
{
    public static RouteGroupBuilder AddClassRoomGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("classroom/create", async ([FromServices] HttpContext _context, [FromServices] IClassRoomService _service, [FromBody] CreateClassRoomRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreateClassRoomAsync(request, new CallOptions { });
        });

        group.MapPatch("classroom/update", async ([FromServices] HttpContext _context, [FromServices] IClassRoomService _service, [FromBody] UpdateClassRoomRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdateClassRoomAsync(request, new CallOptions { });
        });

        group.MapDelete("classroom/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] IClassRoomService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeleteClassRoomAsync(new DeleteClassRoomRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("classroom/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] IClassRoomService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetClassRoomByIdAsync(new GetClassRoomByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("classroom/all", async ([FromServices] HttpContext _context, [FromServices] IClassRoomService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllClassRoomAsync(new GetAllClassRoomsRequest { Correlationid = Guid.NewGuid().ToString()}, new CallOptions { });
        });

        return group;
    }
}