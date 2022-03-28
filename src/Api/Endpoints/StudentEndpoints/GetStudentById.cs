namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetStudentById : EndpointBaseAsync.WithRequest<GetStudentByIdRequest>.WithActionResult<GetStudentByIdResponse>
{
    private readonly IStudentService _service;

    private readonly ILogger<CreateStudent> _logger;

    public GetStudentById(ILogger<CreateStudent> logger, IStudentService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(Student), 200, "application/json")]
    public async override Task<ActionResult<GetStudentByIdResponse>> HandleAsync([FromRoute] GetStudentByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetStudentByIdAsync(request, cancellationToken);
    }
}
