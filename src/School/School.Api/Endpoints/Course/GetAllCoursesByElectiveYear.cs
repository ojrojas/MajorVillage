namespace School.Api.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAllCoursesByElectiveYear :
	EndpointBaseAsync.WithRequest<GetAllCoursesByElectiveYearRequest>.WithResult<GetAllCoursesByElectiveYearResponse>
{
    private readonly ICourseService _service;

    public GetAllCoursesByElectiveYear(ICourseService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{ElectiveYearId}")]
    [Produces(typeof(GetAllCoursesByElectiveYearResponse))]
    [SwaggerOperation(
      Summary = "Get All Courses by elective year",
      Description = "Get All Courses by Elective Year",
      OperationId = "Course.getallcoursesbyelectiveyear",
      Tags = new[] { "CourseEndpoints" })]
    public override async Task<GetAllCoursesByElectiveYearResponse> HandleAsync(
        [FromRoute]GetAllCoursesByElectiveYearRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetAllCoursesByElectiveYearAsync(request, cancellationToken);
    }
}

