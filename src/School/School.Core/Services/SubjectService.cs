namespace School.Core.Services;

public class SubjectService //: ISubjectService
{
    private readonly SubjectRepository _repository;
    private readonly ILoggerApplicationService<SubjectService> _logger;

    public SubjectService(SubjectRepository repository, ILoggerApplicationService<SubjectService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    //public async ValueTask<CreateSubjectResponse> CreateSubjectAsync(CreateSubjectRequest request, CancellationToken cancellationToken)
    //{
    //    CreateSubjectResponse response = new(request.CorrelationId());
    //    _logger.LogInformation(response, "Create Subject request");
    //    response.SubjectCreated = await _repository.CreateAsync(request.Subject, cancellationToken);
    //    _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Subject)}");

    //    return response;
    //}

    //public async ValueTask<UpdateSubjectResponse> UpdateSubjectAsync(UpdateSubjectRequest request, CancellationToken cancellationToken)
    //{
    //    UpdateSubjectResponse response = new UpdateSubjectResponse(request.CorrelationId());
    //    _logger.LogInformation(response, "Update Subject request");
    //    response.SubjectUpdated = await _repository.UpdateAsync(request.Subject, cancellationToken);
    //    _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Subject)}");

    //    return response;
    //}

    //public async ValueTask<DeleteSubjectResponse> DeleteSubjectAsync(DeleteSubjectRequest request, CancellationToken cancellationToken)
    //{
    //    DeleteSubjectResponse response = new(request.CorrelationId());
    //    _logger.LogInformation(response, "Delete Subject request");
    //    var SubjectToDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
    //    response.IsSubjectDeleted = await _repository.DeleteAsync(SubjectToDelete, cancellationToken) is not null;
    //    _logger.LogInformation($"Delete record params {request.Id}");

    //    return response;
    //}

    //public async ValueTask<GetSubjectByIdResponse> GetSubjectByIdAsync(GetSubjectByIdRequest request, CancellationToken cancellationToken)
    //{
    //    GetSubjectByIdResponse response = new GetSubjectByIdResponse(request.CorrelationId());
    //    _logger.LogInformation(response, "Get Subject by id request");
    //    response.Subject = await _repository.GetByIdAsync(request.Id, cancellationToken);
    //    _logger.LogInformation($"Get by id Subject params {request.Id}");

    //    return response;
    //}

    //public async ValueTask<GetAllSubjectsResponse> GetAllSubjectsAsync(GetAllSubjectsRequest request, CancellationToken cancellationToken)
    //{
    //    GetAllSubjectsResponse response = new(request.CorrelationId());
    //    _logger.LogInformation(response, "Get all Subjects request");
    //    response.Subjects = await _repository.ListAsync(cancellationToken);
    //    _logger.LogInformation($"Get all Subjects response count: {response.Subjects.Count()}");

    //    return response;
    //}
}

