namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAttendantById : EndpointBaseAsync.WithRequest<GetAttendantByIdRequest>.WithResult<GetAttendantByIdResponse>
{
    private readonly IAttendantService _service;

    public GetAttendantById(IAttendantService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{Id}")]
    [Produces(typeof(GetAttendantByIdResponse))]
    [SwaggerOperation(
    Summary = "Get Attendant by id ",
    Description = "Get Attendant by id",
    OperationId = "Attendant.getallAttendant",
    Tags = new[] { "AttendantEndpoints" })]
    public override async Task<GetAttendantByIdResponse> HandleAsync([FromRoute]GetAttendantByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetAttendantByIdAsync(request, cancellationToken);
    }
}

