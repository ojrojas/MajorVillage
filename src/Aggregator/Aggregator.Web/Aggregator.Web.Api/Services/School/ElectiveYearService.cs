namespace Aggregator.Web.Api.Services;

public class ElectiveYearService : IElectiveYearService
{
    private readonly ILoggerApplicationService<ElectiveYearService> _logger;
    private readonly GrpcSchool.ElectiveYearService.ElectiveYearServiceClient _client;

    public ElectiveYearService(ILoggerApplicationService<ElectiveYearService> logger, GrpcSchool.ElectiveYearService.ElectiveYearServiceClient client)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<CreateElectiveYearResponse> CreateElectiveYearAsync(CreateElectiveYearRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create ElectiveYear");
        return await _client.CreateElectiveYearAsync(request, callOptions);
    }

    public async ValueTask<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElectiveYearRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update ElectiveYear");
        return await _client.UpdateElectiveYearAsync(request, callOptions);
    }

    public async ValueTask<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete ElectiveYear");
        return await _client.DeleteElectiveYearAsync(request, callOptions);
    }

    public async ValueTask<GetElectiveYearByIdResponse> GetElectiveYearByIdAsync(GetElectiveYearByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get ElectiveYear");
        return await _client.GetElectiveYearByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllElectivesYearsResponse> GetAllElectiveYearsAsync(GetAllElectivesYearsRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all ElectiveYears");
        return await _client.GetAllElectivesYearsAsync(request, callOptions);
    }
}