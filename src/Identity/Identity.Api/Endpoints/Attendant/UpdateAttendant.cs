namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UpdateAttendant : EndpointBaseAsync.WithRequest<UpdateAttendantRequest>.WithResult<UpdateAttendantResponse>
{
    private readonly IAttendantService _service;

    public UpdateAttendant(IAttendantService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [Produces(typeof(UpdateAttendantResponse))]
    [SwaggerOperation(
     Summary = "Update Attendant",
     Description = "Update Attendant",
     OperationId = "Attendant.updateAttendant",
     Tags = new[] { "AttendantEndpoints" })]
    public override async Task<UpdateAttendantResponse> HandleAsync(UpdateAttendantRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.UpdateAttendantAsync(request, cancellationToken);
    }
}

