namespace Aggregator.Web.Api.Endpoints;

public static class EnrollmentGroupRoute
{
    public static RouteGroupBuilder AddEnrollmentGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("enrollment/create", async ([FromServices] HttpContext _context, [FromServices] IEnrollmentService _service, [FromBody] CreateEnrollmentRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreateEnrollmentAsync(request, new CallOptions { });
        });

        group.MapPatch("enrollment/update", async ([FromServices] HttpContext _context, [FromServices] IEnrollmentService _service, [FromBody] UpdateEnrollmentRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdateEnrollmentAsync(request, new CallOptions { });
        });

        group.MapDelete("enrollment/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] IEnrollmentService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeleteEnrollmentAsync(new DeleteEnrollmentRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("enrollment/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] IEnrollmentService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetEnrollmentByIdAsync(new GetEnrollmentByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("enrollment/all", async ([FromServices] HttpContext _context, [FromServices] IEnrollmentService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllEnrollmentsAsync(new GetAllEnrollmentsRequest { Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("enrollment/allenrollmentbyelectiveyear/{id}", async ([FromServices] HttpContext _context, [FromServices] IEnrollmentService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllEnrollmentsByElectiveYearIdAsync(new GetAllEnrollmentsByElectiveYearRequest { Electiveyearid = id, Corrleationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        return group;
    }
}