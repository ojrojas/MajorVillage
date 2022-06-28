namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateEnrollment : EndpointBaseAsync.WithRequest<CreateEnrollmentRequest>.WithActionResult<CreateEnrollmentResponse>
{
    private readonly ILogger<CreateEnrollment> _logger;
    private readonly IEnrollmentService _service;

    public CreateEnrollment(ILogger<CreateEnrollment> logger, IEnrollmentService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateEnrollmentResponse))]
    [SwaggerOperation(
              Summary = "Create enrollment",
              Description = "Create enrollment",
              OperationId = "enrollment.createEnrollment",
              Tags = new[] { "EnrollmentEndpoint" })]
    public override async Task<ActionResult<CreateEnrollmentResponse>> HandleAsync(CreateEnrollmentRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Request create enrollment {request}");
        return await _service.CreateEnrollment(request, cancellationToken);
    }
}
