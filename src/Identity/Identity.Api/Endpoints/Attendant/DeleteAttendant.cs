namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeleteAttendant : EndpointBaseAsync.WithRequest<DeleteAttendantRequest>.WithResult<DeleteAttendantResponse>
{
    private readonly IAttendantService _service;

    public DeleteAttendant(IAttendantService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete("{Id}")]
    [Produces(typeof(CreateAttendantResponse))]
    [SwaggerOperation(
      Summary = "Delete Attendant",
      Description = "Delete Attendant",
      OperationId = "Attendant.deleteAttendant",
      Tags = new[] { "AttendantEndpoints" })]
    public override async Task<DeleteAttendantResponse> HandleAsync([FromRoute]DeleteAttendantRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteAttendantAsync(request, cancellationToken);
    }
}

