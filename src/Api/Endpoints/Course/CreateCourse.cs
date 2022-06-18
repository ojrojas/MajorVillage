namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateCourse : EndpointBaseAsync.WithRequest<CreateCourseRequest>.WithResult<CreateCourseResponse>
{
    private readonly ILogger<CreateCourse> _logger;
    private readonly ICourseService _service;

    public CreateCourse(ILogger<CreateCourse> logger, ICourseService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    [Produces(typeof(CreateCourseResponse))]
    [SwaggerOperation(
          Summary = "Create course",
          Description = "Create course",
          OperationId = "course.createcourse",
          Tags = new[] { "CourseEndpoints" })]
    public override async Task<CreateCourseResponse> HandleAsync(CreateCourseRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateCourse(request, cancellationToken);
    }
}
