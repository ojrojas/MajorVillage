namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateStudent : EndpointBaseAsync.WithRequest<CreateStudentRequest>.WithActionResult<CreateStudentResponse>
{
    private readonly IStudentService _service;

    private readonly ILogger<CreateStudent> _logger;

    public CreateStudent(ILogger<CreateStudent> logger, IStudentService service)
    {
        _logger = logger;
        _service = service;
    }
  
    [HttpPost]
    [ProducesResponseType(typeof(Student), 200, "application/json")]
    public async override Task<ActionResult<CreateStudentResponse>> HandleAsync(CreateStudentRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateStudentAsync(request, cancellationToken);
    }
}
