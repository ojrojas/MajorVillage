namespace School.Api.Endpoints.Enrollment;

[Authorize]
[Route("api/[controller]")]
public class GetAllEnrollments : EndpointBaseAsync.WithoutRequest.WithResult<GetAllEnrollmentResponse>
{
    private readonly IEnrollmentService _service;

    public GetAllEnrollments(IEnrollmentService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllEnrollmentResponse))]
    [SwaggerOperation(
     Summary = "Get all enrollmens",
     Description = "Get all enrollments",
     OperationId = "Enrollment.getallenrollments",
     Tags = new[] { "EnrollmentEndpoints" })]
    public override async Task<GetAllEnrollmentResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await _service.GetAllEnrollmentsAsync(new GetAllEnrollmentRequest(), cancellationToken);
    }
}