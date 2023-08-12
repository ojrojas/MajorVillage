namespace School.Core.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly ILoggerApplicationService<EnrollmentService> _logger;
    private readonly EnrollmentRepository _repository;
    private readonly IMapper _mapper;

    public EnrollmentService(ILoggerApplicationService<EnrollmentService> logger, EnrollmentRepository repository, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreateEnrollmentResponse> CreateEnrollmentAsync(CreateEnrollmentRequest request, CancellationToken cancellationToken)
    {
        CreateEnrollmentResponse response = new();
        _logger.LogInformation(request.Correlationid, "Create course request");
        response.Enrollmentcreated = _mapper.Map<GrpcSchool.Enrollment>(await _repository.CreateAsync(_mapper.Map<Enrollment>(request.Enrollment), cancellationToken));
        _logger.LogInformation($"Create Enrollment entity: {JsonSerializer.Serialize(request.Enrollment)}");
        return response;
    }

    public async ValueTask<UpdateEnrollmentResponse> UpdateEnrollmentAsync(UpdateEnrollmentRequest request, CancellationToken cancellationToken)
    {
        UpdateEnrollmentResponse response = new();
        _logger.LogInformation(request.Correlationid, "Update course request");
        response.Enrollmentupdated = _mapper.Map<GrpcSchool.Enrollment>(await _repository.UpdateAsync(_mapper.Map<Enrollment>(request.Enrollment), cancellationToken));
        _logger.LogInformation($"Update Enrollment entity: {JsonSerializer.Serialize(request.Enrollment)}");
        return response;
    }

    public async ValueTask<DeleteEnrollmentResponse> DeleteEnrollmentAsync(DeleteEnrollmentRequest request, CancellationToken cancellationToken)
    {
        DeleteEnrollmentResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        var entity = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        response.Isenrollmentdeleted = await _repository.DeleteAsync(entity, cancellationToken) is not null;
        _logger.LogInformation($"Delete Enrollment entity: {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async ValueTask<GetEnrollmentByIdResponse> GetEnrollmentByIdAsync(GetEnrollmentByIdRequest request, CancellationToken cancellationToken)
    {
        GetEnrollmentByIdResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        response.Enrollment = _mapper.Map<GrpcSchool.Enrollment>( await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Delete Enrollment entity: {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsAsync(GetAllEnrollmentsRequest request, CancellationToken cancellationToken)
    {
        GetAllEnrollmentsResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        response.Enrollments.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<Enrollment, GrpcSchool.Enrollment>(_mapper));
        _logger.LogInformation($"Get all Enrollments {response.Enrollments.Count()}");
        return response;
    }

    public async ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsByElectiveYearAsync(GetAllEnrollmentsByElectiveYearRequest request, CancellationToken cancellationToken)
    {
        GetAllEnrollmentsResponse response = new();
        _logger.LogInformation(request.Corrleationid, "Get all courses request");
        var specificationByElectiveYearId = new EnrollmentSpecification(Guid.Parse(request.Electiveyearid));
        response.Enrollments.AddRange((await _repository.ListAsync(specificationByElectiveYearId, cancellationToken)).ToRepeatedTypeAsync<Enrollment, GrpcSchool.Enrollment>(_mapper));
        _logger.LogInformation($"Get all Enrollments by elective year request elective year id {request.Electiveyearid}");
        return response;
    }
}