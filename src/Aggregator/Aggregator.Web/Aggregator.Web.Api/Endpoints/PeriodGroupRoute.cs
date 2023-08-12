namespace Aggregator.Web.Api.Endpoints;

public static class PeriodGroupRoute
{
    public static RouteGroupBuilder AddPeriodGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("period/create", async ([FromServices] HttpContext _context, [FromServices] IPeriodService _service, [FromBody] CreatePeriodRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreatePeriodAsync(request, new CallOptions { });
        });

        group.MapPatch("period/update", async ([FromServices] HttpContext _context, [FromServices] IPeriodService _service, [FromBody] UpdatePeriodRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdatePeriodAsync(request, new CallOptions { });
        });

        group.MapDelete("period/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] IPeriodService _service, [FromRoute]string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeletePeriodAsync(new DeletePeriodRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("period/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] IPeriodService _service,[FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetPeriodByIdAsync(new GetPeriodByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("period/all", async ([FromServices] HttpContext _context, [FromServices] IPeriodService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllPeriodsAsync(new GetAllPeriodsRequest { Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        return group;
    }
}