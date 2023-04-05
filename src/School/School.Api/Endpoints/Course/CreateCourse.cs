namespace School.Api.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateCourse : EndpointBaseAsync.WithRequest<CreateCourseRequest>.WithResult<CreateCourseResponse>
{
    private readonly ICourseService _service;

    public CreateCourse(ICourseService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateCourseResponse))]
    [SwaggerOperation(
      Summary = "Create Course",
      Description = "Create Course",
      OperationId = "Course.createcourse",
      Tags = new[] { "CourseEndpoints" })]
    public override async Task<CreateCourseResponse> HandleAsync(CreateCourseRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateCourseAsync(request, cancellationToken);
    }
}

