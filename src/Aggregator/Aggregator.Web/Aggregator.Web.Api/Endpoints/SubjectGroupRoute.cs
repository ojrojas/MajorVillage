namespace Aggregator.Web.Api.Endpoints;

public static class SubjectGroupRoute
{
    public static RouteGroupBuilder AddSubjectGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("subject/create", async ([FromServices] HttpContext _context, [FromServices] ISubjectService _service, [FromBody] CreateSubjectRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreateSubjectAsync(request, new CallOptions { });
        });

        group.MapPatch("subject/update", async ([FromServices] HttpContext _context, [FromServices] ISubjectService _service,[FromBody] UpdateSubjectRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdateSubjectAsync(request, new CallOptions { });
        });

        group.MapDelete("subject/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] ISubjectService _service,[FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeleteSubjectAsync(new DeleteSubjectRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("subject/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] ISubjectService _service, [FromRoute]string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetSubjectByIdAsync(new GetSubjectByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("subject/all", async ([FromServices]HttpContext _context, [FromServices] ISubjectService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllSubjectsAsync(new GetAllSubjectsRequest { Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        return group;
    }
}