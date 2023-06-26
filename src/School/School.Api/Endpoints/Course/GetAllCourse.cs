namespace School.Api.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAllCourse: EndpointBaseAsync.WithoutRequest.WithResult<GetAllCoursesResponse>
{
	private readonly ICourseService _service;

    public GetAllCourse(ICourseService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllCoursesResponse))]
    [SwaggerOperation(
      Summary = "Get All Courses",
      Description = "Get All Courses",
      OperationId = "Course.getallcourses",
      Tags = new[] { "CourseEndpoints" })]
    public override async Task<GetAllCoursesResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await _service.GetAllCoursesAsync(new(), cancellationToken);
    }
}

