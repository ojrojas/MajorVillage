namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class DeleteCourse : EndpointBaseAsync.WithRequest<DeleteCourseRequest>.WithResult<DeleteCourseResponse>
{

    private readonly ILogger<DeleteCourse> _logger;
    private readonly ICourseService _service;

    public DeleteCourse(ILogger<DeleteCourse> logger, ICourseService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete]
    [Produces(typeof(DeleteCourseResponse))]
    [SwaggerOperation(
          Summary = "Delete course",
          Description = "Delete course",
          OperationId = "course.deletecourse",
          Tags = new[] { "CourseEndpoints" })]
    public override async Task<DeleteCourseResponse> HandleAsync(DeleteCourseRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"DeleteCourse request ${request}");
        return await _service.DeleteCourse(request, cancellationToken);
    }
}
