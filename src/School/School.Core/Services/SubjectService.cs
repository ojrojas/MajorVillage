namespace School.Core.Services;

public class SubjectService : ISubjectService
{
    private readonly SubjectRepository _repository;
    private readonly ILoggerApplicationService<SubjectService> _logger;
    private readonly IMapper _mapper;

    public SubjectService(SubjectRepository repository, ILoggerApplicationService<SubjectService> logger, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreateSubjectResponse> CreateSubjectAsync(CreateSubjectRequest request, CancellationToken cancellationToken)
    {
        CreateSubjectResponse response = new();
        _logger.LogInformation(request.Correlationid, "Create Subject request");
        response.Subjectcreated = _mapper.Map<GrpcSchool.Subject>(await _repository.CreateAsync(_mapper.Map<Subject>(request.Subject), cancellationToken));
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Subject)}");

        return response;
    }

    public async ValueTask<UpdateSubjectResponse> UpdateSubjectAsync(UpdateSubjectRequest request, CancellationToken cancellationToken)
    {
        UpdateSubjectResponse response = new();
        _logger.LogInformation(request.Correlationid, "Update Subject request");
        response.Subjectupdated = _mapper.Map<GrpcSchool.Subject>(await _repository.UpdateAsync(_mapper.Map<Subject>(request.Subject), cancellationToken));
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Subject)}");

        return response;
    }

    public async ValueTask<DeleteSubjectResponse> DeleteSubjectAsync(DeleteSubjectRequest request, CancellationToken cancellationToken)
    {
        DeleteSubjectResponse response = new();
        _logger.LogInformation(request.Correlationid, "Delete Subject request");
        var SubjectToDelete = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        response.Issubjectdeleted = await _repository.DeleteAsync(SubjectToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetSubjectByIdResponse> GetSubjectByIdAsync(GetSubjectByIdRequest request, CancellationToken cancellationToken)
    {
        GetSubjectByIdResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get Subject by id request");
        response.Subject = _mapper.Map<GrpcSchool.Subject>(await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Get by id Subject params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllSubjectsResponse> GetAllSubjectsAsync(GetAllSubjectsRequest request, CancellationToken cancellationToken)
    {
        GetAllSubjectsResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all Subjects request");
        response.Subjects.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<Subject, GrpcSchool.Subject>(_mapper));
        _logger.LogInformation($"Get all Subjects response count: {response.Subjects.Count()}");

        return response;
    }
}

