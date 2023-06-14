namespace School.Api.Endpoints.Enrollment;

[Authorize]
[Route("api/[controller]")]
public class DeleteEnrollment : EndpointBaseAsync.WithRequest<DeleteEnrollmentRequest>.WithResult<DeleteEnrollmentResponse>
{
    private readonly IEnrollmentService _service;

    public DeleteEnrollment(IEnrollmentService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete]
    [Consumes("application/json")]
    [Produces(typeof(UpdateEnrollmentResponse))]
    [SwaggerOperation(
     Summary = "Delete enrollmen",
     Description = "Delete enrollment",
     OperationId = "Enrollment.deleteenrollment",
     Tags = new[] { "EnrollmentEndpoints" })]
    public override async Task<DeleteEnrollmentResponse> HandleAsync(DeleteEnrollmentRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteEnrollmentAsync(request, cancellationToken);
    }
}

