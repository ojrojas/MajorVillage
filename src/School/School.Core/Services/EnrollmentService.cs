namespace School.Core.Services;

public class EnrollmentService //: IEnrollmentService
{
    private readonly ILogger<EnrollmentService> _logger;
    private readonly EnrollmentRepository _repository;

    public EnrollmentService(ILogger<EnrollmentService> logger, EnrollmentRepository repository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    //public async ValueTask<CreateEnrollmentResponse> CreateEnrollmentAsync(CreateEnrollmentRequest request, CancellationToken cancellationToken)
    //{
    //    CreateEnrollmentResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Create Enrollment request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.Enrollment)}");
    //    response.EnrollmentCreated = await _repository.CreateAsync(request.Enrollment, cancellationToken);
    //    return response;
    //}

    //public async ValueTask<UpdateEnrollmentResponse> UpdateEnrollmentAsync(UpdateEnrollmentRequest request, CancellationToken cancellationToken)
    //{
    //    UpdateEnrollmentResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Update Enrollment request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.Enrollment)}");
    //    response.EnrollmentUpdated = await _repository.UpdateAsync(request.Enrollment, cancellationToken);
    //    return response;
    //}

    //public async ValueTask<DeleteEnrollmentResponse> DeleteEnrollmentAsync(DeleteEnrollmentRequest request, CancellationToken cancellationToken)
    //{
    //    DeleteEnrollmentResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Delete Enrollment request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.Id)}");
    //    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
    //    response.EnrollmentDeleted = await _repository.DeleteAsync(entity, cancellationToken);
    //    return response;
    //}

    //public async ValueTask<GetAllEnrollmentResponse> GetAllEnrollmentsAsync(GetAllEnrollmentRequest request, CancellationToken cancellationToken)
    //{
    //    GetAllEnrollmentResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Get all Enrollments request id: {response.CorrelationId}");
    //    response.Enrollments = await _repository.ListAsync(cancellationToken);
    //    return response;
    //}

    //public async ValueTask<GetAllEnrollmentByElectiveYearResponse> GetAllEnrollmentsByElectiveYearAsync(
    //    GetAllEnrollmentByElectiveYearRequest request, CancellationToken cancellationToken)
    //{
    //    GetAllEnrollmentByElectiveYearResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Get all Enrollments by elective year request id: {response.CorrelationId}, elective year: {JsonSerializer.Serialize(request.ElectiveYearId)}");
    //    var specificationByElectiveYearId = new EnrollmentSpecification(request.ElectiveYearId);
    //    response.Enrollments = await _repository.ListAsync(specificationByElectiveYearId, cancellationToken);
    //    return response;
    //}
}