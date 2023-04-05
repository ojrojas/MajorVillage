namespace School.Api.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UpdateCourse : EndpointBaseAsync.WithRequest<UpdateCourseRequest>.WithResult<UpdateCourseResponse>
{
    private readonly ICourseService _service;

    public UpdateCourse(ICourseService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [Produces(typeof(UpdateCourseResponse))]
    [SwaggerOperation(
      Summary = "Update Course",
      Description = "Update Course",
      OperationId = "Course.updatecourse",
      Tags = new[] { "CourseEndpoints" })]
    public override async Task<UpdateCourseResponse> HandleAsync(UpdateCourseRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.UpdateCourseAsync(request, cancellationToken);
    }
}

