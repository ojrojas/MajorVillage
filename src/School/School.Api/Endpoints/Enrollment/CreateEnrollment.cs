namespace School.Api.Endpoints.Enrollment;

[Authorize]
[Route("api/[controller]")]
public class CreateEnrollment : EndpointBaseAsync.WithRequest<CreateEnrollmentRequest>.WithResult<CreateEnrollmentResponse>
{
    private readonly IEnrollmentService _service;

    public CreateEnrollment(IEnrollmentService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces(typeof(CreateEnrollmentResponse))]
    [SwaggerOperation(
     Summary = "Create enrollmen",
     Description = "Create enrollment",
     OperationId = "Enrollment.createenrollment",
     Tags = new[] { "EnrollmentEndpoints" })]
    public override async Task<CreateEnrollmentResponse> HandleAsync(CreateEnrollmentRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateEnrollmentAsync(request, cancellationToken);
    }
}

