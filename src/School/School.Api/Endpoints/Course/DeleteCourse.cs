namespace School.Api.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeleteCourse : EndpointBaseAsync.WithRequest<DeleteCourseRequest>.WithResult<DeleteCourseResponse>
{
    private readonly ICourseService _service;

    public DeleteCourse(ICourseService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete("{Id}")]
    [Produces(typeof(DeleteCourseResponse))]
    [SwaggerOperation(
      Summary = "Delete Courses",
      Description = "Delete Courses",
      OperationId = "Course.deletecourse",
      Tags = new[] { "CourseEndpoints" })]
    public override async Task<DeleteCourseResponse> HandleAsync(
        [FromRoute]DeleteCourseRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteCourseAsync(request, cancellationToken);
    }
}

