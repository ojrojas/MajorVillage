namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class UpdateEnrollment : EndpointBaseAsync.WithRequest<UpdateEnrollmentRequest>.WithResult<UpdateEnrollmentResponse>
{
    private readonly ILogger<UpdateEnrollment> _logger;
    private readonly IEnrollmentService _service;

    public UpdateEnrollment(ILogger<UpdateEnrollment> logger, IEnrollmentService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPut]
    [Produces(typeof(UpdateEnrollmentResponse))]
    [SwaggerOperation(
              Summary = "Update enrollment",
              Description = "Update enrollment",
              OperationId = "enrollment.updateEnrollment",
              Tags = new[] { "EnrollmentEndpoint" })]
    public override async Task<UpdateEnrollmentResponse> HandleAsync(UpdateEnrollmentRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"UpdateEnrollment Request {request}");
        return await _service.UpdateEnrollment(request, cancellationToken);
    }
}
