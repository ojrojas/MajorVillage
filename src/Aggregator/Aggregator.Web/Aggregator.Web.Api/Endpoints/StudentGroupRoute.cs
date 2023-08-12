namespace Aggregator.Web.Api.Endpoints;

public static class StudentGroupRoute
{
    public static RouteGroupBuilder AddStudentGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("student/create", async ([FromServices] HttpContext _context, [FromServices] IStudentService _service, [FromBody] CreateStudentRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreateStudentAsync(request, new CallOptions { });
        });

        group.MapPatch("student/update", async ([FromServices] HttpContext _context, [FromServices] IStudentService _service, [FromBody] UpdateStudentRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdateStudentAsync(request, new CallOptions { });
        });

        group.MapDelete("student/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] IStudentService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeleteStudentAsync(new DeleteStudentRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("student/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] IStudentService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetStudentByIdAsync(new GetStudentByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("student/all", async ([FromServices] HttpContext _context, [FromServices] IStudentService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
               throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllStudentsAsync(new GetAllStudentsRequest { Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        return group;
    }
}