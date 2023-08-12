namespace Aggregator.Web.Api.Services;

public class AreaService : IAreaService
{
    private readonly GrpcSchool.AreaService.AreaServiceClient _client;
    private readonly ILoggerApplicationService<AreaService> _logger;

    public AreaService(GrpcSchool.AreaService.AreaServiceClient client, ILoggerApplicationService<AreaService> logger)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateAreaResponse> CreateAreaAsync(CreateAreaRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create area");
        return await _client.CreateAreaAsync(request, callOptions);
    }

    public async ValueTask<UpdateAreaResponse> UpdateAreaAsync(UpdateAreaRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update area");
        return await _client.UpdateAreaAsync(request, callOptions);
    }

    public async ValueTask<DeleteAreaResponse> DeleteAreaAsync(DeleteAreaRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete area");
        return await _client.DeleteAreaAsync(request, callOptions);
    }

    public async ValueTask<GetAreaByIdResponse> GetAreaByIdAsync(GetAreaByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get area by id");
        return await _client.GetAreaByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllAreasResponse> GetAllAreasAsync(GetAllAreasRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all areas");
        return await _client.GetAllAreasAsync(request, callOptions);
    }
}

