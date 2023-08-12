namespace Aggregator.Web.Api.Endpoints;

public static class ElectiveYearGroupRoute
{
    public static RouteGroupBuilder AddElectiveYearGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("electiveyear/create", async ([FromServices] HttpContext _context, [FromServices] IElectiveYearService _service, [FromBody] CreateElectiveYearRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreateElectiveYearAsync(request, new CallOptions { });
        });

        group.MapPatch("electiveyear/update", async ([FromServices] HttpContext _context, [FromServices] IElectiveYearService _service, [FromBody] UpdateElectiveYearRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdateElectiveYearAsync(request, new CallOptions { });
        });

        group.MapDelete("electiveyear/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] IElectiveYearService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeleteElectiveYearAsync(new DeleteElectiveYearRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("electiveyear/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] IElectiveYearService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetElectiveYearByIdAsync(
                new GetElectiveYearByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("electiveyear/all", async ([FromServices] HttpContext _context, [FromServices] IElectiveYearService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllElectiveYearsAsync(
                new GetAllElectivesYearsRequest { Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });


        return group;
    }
}