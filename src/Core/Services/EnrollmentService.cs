namespace MajorVillage.Core.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repository;
    private readonly ILogger<EnrollmentService> _logger;

    public EnrollmentService(IEnrollmentRepository repository, ILogger<EnrollmentService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<CreateEnrollmentResponse> CreateEnrollment(CreateEnrollmentRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"CreateEnrollmentRequest {request}");
        CreateEnrollmentResponse response = new(request.CorrelationId());
        response.Id = await _repository.CreateEnrollment(request.Enrollment, cancellationToken);
        return response;
    }

    public async Task<UpdateEnrollmentResponse> UpdateEnrollment(UpdateEnrollmentRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"UpdateEnrollmentRequest {request}");
        UpdateEnrollmentResponse response = new(request.CorrelationId());
        response.EnrollmentUpdated = await _repository.UpdateEnrollment(request.Enrollment, cancellationToken);
        return response;
    }

    public async Task<DeleteEnrollmentResponse> DeleteEnrollment(DeleteEnrollmentRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"DeleteEnrollmentRequest {request}");
        DeleteEnrollmentResponse response = new(request.CorrelationId());
        response.DeleteEnrollmentDeleted = await _repository.UpdateEnrollment(request.Enrollment, cancellationToken);
        return response;
    }

    public async Task<GetByIdEnrollmentResponse> GetEnrollmentById(GetByIdEnrollmentRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"GetByIdEnrollmentRequest {request}");
        GetByIdEnrollmentResponse response = new(request.CorrelationId());
        response.Enrollment = await _repository.GetEnrollmentById(request.Id, cancellationToken);
        return response;
    }
}