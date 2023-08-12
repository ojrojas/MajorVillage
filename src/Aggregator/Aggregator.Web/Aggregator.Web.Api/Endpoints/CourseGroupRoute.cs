namespace Aggregator.Web.Api.Endpoints;

public static class CourseGroupRoute
{
    public static RouteGroupBuilder AddCourseGroupRoute(this RouteGroupBuilder group)
    {
        group.MapPost("course/create", async ([FromServices] HttpContext _context, [FromServices] ICourseService _service, [FromBody] CreateCourseRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
           throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.CreateCourseAsync(request, new CallOptions { });
        });

        group.MapPatch("course/update", async ([FromServices] HttpContext _context, [FromServices] ICourseService _service, [FromBody] UpdateCourseRequest request) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
           throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.UpdateCourseAsync(request, new CallOptions { });
        });

        group.MapDelete("course/delete/{id}", async ([FromServices] HttpContext _context, [FromServices] ICourseService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
           throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.DeleteCourseAsync(new DeleteCourseRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("course/getbyid/{id}", async ([FromServices] HttpContext _context, [FromServices] ICourseService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
           throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetCourseByIdAsync(new GetCourseByIdRequest { Id = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("course/all", async ([FromServices] HttpContext _context, [FromServices] ICourseService _service) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
           throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllCoursesAsync(new GetAllCoursesRequest { Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        group.MapGet("course/allbyelectiveyear/{id}", async ([FromServices] HttpContext _context, [FromServices] ICourseService _service, [FromRoute] string id) =>
        {
            var result = await _context.AuthenticateAsync(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme) ??
           throw new InvalidOperationException("Error request opration not found a valid request open iddict");
            return await _service.GetAllCoursesByElectiveYearAsync(new GetAllCoursesByElectiveYearRequest { Electiveyearid = id, Correlationid = Guid.NewGuid().ToString() }, new CallOptions { });
        });

        return group;
    }
}