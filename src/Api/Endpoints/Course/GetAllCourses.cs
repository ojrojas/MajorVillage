namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetAllCourses : EndpointBaseAsync.WithRequest<GetAllCoursesRequest>.WithResult<GetAllCoursesResponse>
{
    private readonly ILogger<GetAllCourses> _logger;
    private readonly ICourseService _service;

    public GetAllCourses(ILogger<GetAllCourses> logger, ICourseService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllCoursesResponse))]
    [SwaggerOperation(
          Summary = "Get all courses",
          Description = "Get all courses",
          OperationId = "course.getallcourses",
          Tags = new[] { "CourseEndpoints" })]
    public override async Task<GetAllCoursesResponse> HandleAsync(
        [FromQuery]GetAllCoursesRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"GetAllCourses request ${request}");
        return await _service.GetAllCourses(request, cancellationToken);
    }
}
