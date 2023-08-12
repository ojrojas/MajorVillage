namespace Aggregator.Web.Api.Services;

public class PeriodService : IPeriodService
{
    private readonly ILoggerApplicationService<PeriodService> _logger;
    private readonly GrpcSchool.PeriodService.PeriodServiceClient _client;

    public PeriodService(ILoggerApplicationService<PeriodService> logger, GrpcSchool.PeriodService.PeriodServiceClient client)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create Period");
        return await _client.CreatePeriodAsync(request, callOptions);
    }

    public async ValueTask<UpdatePeriodResponse> UpdatePeriodAsync(UpdatePeriodRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update Period");
        return await _client.UpdatePeriodAsync(request, callOptions);
    }

    public async ValueTask<DeletePeriodResponse> DeletePeriodAsync(DeletePeriodRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete Period");
        return await _client.DeletePeriodAsync(request, callOptions);
    }

    public async ValueTask<GetPeriodByIdResponse> GetPeriodByIdAsync(GetPeriodByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get Period");
        return await _client.GetPeriodByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllPeriodsResponse> GetAllPeriodsAsync(GetAllPeriodsRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all Periods");
        return await _client.GetAllsPeriodsAsync(request, callOptions);
    }
}