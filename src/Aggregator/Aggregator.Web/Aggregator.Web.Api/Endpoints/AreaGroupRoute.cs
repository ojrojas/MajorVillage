namespace Aggregator.Web.Api.Endpoints;

public static class AreaGroupRoute
{
    public static RouteGroupBuilder AddAreaGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("area/create", async ([FromServices] HttpContext _context, [FromServices] IAreaService _service, [FromBody] CreateAreaRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreateAreaAsync(request, new CallOptions { });
        });

        group.MapPatch("area/update", async ([FromServices] HttpContext _context, [FromServices] IAreaService _service, [FromBody] UpdateAreaRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdateAreaAsync(request, new CallOptions { });
        });

        group.MapDelete("area/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] IAreaService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeleteAreaAsync(new DeleteAreaRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("area/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] IAreaService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAreaByIdAsync(new GetAreaByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("area/all", async ([FromServices] HttpContext _context, [FromServices] IAreaService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
            throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllAreasAsync(new GetAllAreasRequest { Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        return group;
    }
}