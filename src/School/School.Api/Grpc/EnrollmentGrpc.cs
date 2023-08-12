namespace School.Api.Grpc;

public class EnrollmentGrpc : GrpcSchool.EnrollmentService.EnrollmentServiceBase
{
    private readonly ILoggerApplicationService<EnrollmentGrpc> _logger;
    private readonly IEnrollmentService _service;

    public EnrollmentGrpc(ILoggerApplicationService<EnrollmentGrpc> logger, IEnrollmentService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreateEnrollmentResponse> CreateEnrollment(CreateEnrollmentRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create enrollmet");
        return await _service.CreateEnrollmentAsync(request, context.CancellationToken);
    }

    public override async Task<UpdateEnrollmentResponse> UpdateEnrollment(UpdateEnrollmentRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive update enrollmet");
        return await _service.UpdateEnrollmentAsync(request, context.CancellationToken);
    }

    public override async Task<DeleteEnrollmentResponse> DeleteEnrollment(DeleteEnrollmentRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive delete enrollmet");
        return await _service.DeleteEnrollmentAsync(request, context.CancellationToken);
    }

    public override async Task<GetEnrollmentByIdResponse> GetEnrollmentById(GetEnrollmentByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get enrollmet by id");
        return await _service.GetEnrollmentByIdAsync(request, context.CancellationToken);
    }

    public override async Task<GetAllEnrollmentsResponse> GetAllEnrollments(GetAllEnrollmentsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive all enrollmets");
        return await _service.GetAllEnrollmentsAsync(request, context.CancellationToken);
    }
}

