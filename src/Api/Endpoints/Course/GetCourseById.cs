namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetCourseById : EndpointBaseAsync.WithRequest<GetCourseByIdRequest>.WithResult<GetCourseByIdResponse>
{
    private readonly ILogger<GetCourseById> _logger;
    private readonly ICourseService _service;

    public GetCourseById(ILogger<GetCourseById> logger, ICourseService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{Id}")]
    [Produces(typeof(GetCourseByIdResponse))]
    [SwaggerOperation(
          Summary = "Get course by id",
          Description = "Get course by id",
          OperationId = "course.getcoursebyid",
          Tags = new[] { "CourseEndpoints" })]
    public override async Task<GetCourseByIdResponse> HandleAsync([FromRoute]GetCourseByIdRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Get course by id request {request}");
        return await _service.GetCourseById(request, cancellationToken);
    }
}
