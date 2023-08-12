namespace Aggregator.Web.Api.Services;

public class StudentService : IStudentService
{
    private readonly ILoggerApplicationService<StudentService> _logger;
    private readonly GrpcSchool.StudentService.StudentServiceClient _client;

    public StudentService(ILoggerApplicationService<StudentService> logger, GrpcSchool.StudentService.StudentServiceClient client)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create Student");
        return await _client.CreateStudentAsync(request, callOptions);
    }

    public async ValueTask<UpdateStudentResponse> UpdateStudentAsync(UpdateStudentRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update Student");
        return await _client.UpdateStudentAsync(request, callOptions);
    }

    public async ValueTask<DeleteStudentResponse> DeleteStudentAsync(DeleteStudentRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete Student");
        return await _client.DeleteStudentAsync(request, callOptions);
    }

    public async ValueTask<GetStudentByIdResponse> GetStudentByIdAsync(GetStudentByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get Student");
        return await _client.GetStudentByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllStudentsResponse> GetAllStudentsAsync(GetAllStudentsRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all Students");
        return await _client.GetAllStudentsAsync(request, callOptions);
    }
}