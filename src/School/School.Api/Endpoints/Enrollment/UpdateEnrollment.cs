namespace School.Api.Endpoints.Enrollment;

[Authorize]
[Route("api/[controller]")]
public class UpdateEnrollment : EndpointBaseAsync.WithRequest<UpdateEnrollmentRequest>.WithResult<UpdateEnrollmentResponse>
{
    private readonly IEnrollmentService _service;

    public UpdateEnrollment(IEnrollmentService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [Consumes("application/json")]
    [Produces(typeof(UpdateEnrollmentResponse))]
    [SwaggerOperation(
     Summary = "Update enrollmen",
     Description = "Update enrollment",
     OperationId = "Enrollment.updateenrollment",
     Tags = new[] { "EnrollmentEndpoints" })]
    public override async Task<UpdateEnrollmentResponse> HandleAsync(UpdateEnrollmentRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.UpdateEnrollmentAsync(request, cancellationToken);
    }
}

