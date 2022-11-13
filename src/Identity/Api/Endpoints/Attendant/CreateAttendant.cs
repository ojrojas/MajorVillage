namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateAttendant : EndpointBaseAsync.WithRequest<CreateAttendantRequest>.WithResult<CreateAttendantResponse>
{
    private readonly IAttendantService _service;

    public CreateAttendant(IAttendantService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateAttendantResponse))]
    [SwaggerOperation(
      Summary = "Create Attendant",
      Description = "Create Attendant",
      OperationId = "Attendant.createAttendant",
      Tags = new[] { "AttendantEndpoints" })]
    public override async Task<CreateAttendantResponse> HandleAsync(CreateAttendantRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateAttendantAsync(request, cancellationToken);
    }
}

