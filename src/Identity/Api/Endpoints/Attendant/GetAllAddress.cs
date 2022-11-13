namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAllAttendant : EndpointBaseAsync.WithoutRequest.WithResult<GetAllAttendantResponse>
{
    private readonly IAttendantService _service;

    public GetAllAttendant(IAttendantService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllAttendantResponse))]
    [SwaggerOperation(
    Summary = "Get all Attendant",
    Description = "Get all Attendant",
    OperationId = "Attendant.getallAttendant",
    Tags = new[] { "AttendantEndpoints" })]
    public override async Task<GetAllAttendantResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await _service.GetAllAttendantAsync(new(), cancellationToken);
    }
}

