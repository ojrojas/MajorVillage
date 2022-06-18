namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class UpdateCourse : EndpointBaseAsync.WithRequest<UpdateCourseRequest>.WithResult<UpdateCourseResponse>
{
    private readonly ILogger<UpdateCourse> _logger;
    private readonly ICourseService _service;

    public UpdateCourse(ILogger<UpdateCourse> logger, ICourseService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPut]
    [Produces(typeof(UpdateCourseResponse))]
    [SwaggerOperation(
          Summary = "Update course",
          Description = "Update course",
          OperationId = "course.updatecourse",
          Tags = new[] { "CourseEndpoints" })]
    public override async Task<UpdateCourseResponse> HandleAsync(UpdateCourseRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"UpdateCourse request ${request}");
        return await _service.UpdateCourse(request, cancellationToken);
    }
}
