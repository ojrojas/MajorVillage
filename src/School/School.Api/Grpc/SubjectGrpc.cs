namespace School.Api.Grpc;

public class SubjectGrpc: GrpcSchool.SubjectService.SubjectServiceBase
{
    private readonly ILoggerApplicationService<SubjectGrpc> _logger;
    private readonly ISubjectService _service;

    public SubjectGrpc(ILoggerApplicationService<SubjectGrpc> logger, ISubjectService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreateSubjectResponse> CreateSubject(CreateSubjectRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create subject");
        return await _service.CreateSubjectAsync(request, context.CancellationToken);
    }

    public override async Task<UpdateSubjectResponse> UpdateSubject(UpdateSubjectRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive update subject");
        return await _service.UpdateSubjectAsync(request, context.CancellationToken);
    }

    public override async Task<DeleteSubjectResponse> DeleteSubject(DeleteSubjectRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive delete subject");
        return await _service.DeleteSubjectAsync(request, context.CancellationToken);
    }

    public override async Task<GetSubjectByIdResponse> GetSubjectById(GetSubjectByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get subject by id");
        return await _service.GetSubjectByIdAsync(request, context.CancellationToken);
    }

    public override async Task<GetAllSubjectsResponse> GetAllSubjects(GetAllSubjectsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get all subject");
        return await _service.GetAllSubjectsAsync(request, context.CancellationToken);
    }
}

