namespace Aggregator.Web.Api.Services;

public class SubjectService : ISubjectService
{
    private readonly ILoggerApplicationService<SubjectService> _logger;
    private readonly GrpcSchool.SubjectService.SubjectServiceClient _client;

    public SubjectService(ILoggerApplicationService<SubjectService> logger, GrpcSchool.SubjectService.SubjectServiceClient client)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<CreateSubjectResponse> CreateSubjectAsync(CreateSubjectRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create Subject");
        return await _client.CreateSubjectAsync(request, callOptions);
    }

    public async ValueTask<UpdateSubjectResponse> UpdateSubjectAsync(UpdateSubjectRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update Subject");
        return await _client.UpdateSubjectAsync(request, callOptions);
    }

    public async ValueTask<DeleteSubjectResponse> DeleteSubjectAsync(DeleteSubjectRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete Subject");
        return await _client.DeleteSubjectAsync(request, callOptions);
    }

    public async ValueTask<GetSubjectByIdResponse> GetSubjectByIdAsync(GetSubjectByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get Subject");
        return await _client.GetSubjectByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllSubjectsResponse> GetAllSubjectsAsync(GetAllSubjectsRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all Subjects");
        return await _client.GetAllSubjectsAsync(request, callOptions);
    }
}