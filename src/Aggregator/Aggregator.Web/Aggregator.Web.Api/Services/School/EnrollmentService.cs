namespace Aggregator.Web.Api.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly ILoggerApplicationService<EnrollmentService> _logger;
    private readonly GrpcSchool.EnrollmentService.EnrollmentServiceClient _client;

    public EnrollmentService(ILoggerApplicationService<EnrollmentService> logger, GrpcSchool.EnrollmentService.EnrollmentServiceClient client)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<CreateEnrollmentResponse> CreateEnrollmentAsync(CreateEnrollmentRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create Enrollment");
        return await _client.CreateEnrollmentAsync(request, callOptions);
    }

    public async ValueTask<UpdateEnrollmentResponse> UpdateEnrollmentAsync(UpdateEnrollmentRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update Enrollment");
        return await _client.UpdateEnrollmentAsync(request, callOptions);
    }

    public async ValueTask<DeleteEnrollmentResponse> DeleteEnrollmentAsync(DeleteEnrollmentRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete Enrollment");
        return await _client.DeleteEnrollmentAsync(request, callOptions);
    }

    public async ValueTask<GetEnrollmentByIdResponse> GetEnrollmentByIdAsync(GetEnrollmentByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get Enrollment");
        return await _client.GetEnrollmentByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsAsync(GetAllEnrollmentsRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all Enrollments");
        return await _client.GetAllEnrollmentsAsync(request, callOptions);
    }

    public async ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsByElectiveYearIdAsync(GetAllEnrollmentsByElectiveYearRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all Enrollments");
        return await _client.GetAllEnrollmentsByElectiveYearAsync(request, callOptions);
    }
}