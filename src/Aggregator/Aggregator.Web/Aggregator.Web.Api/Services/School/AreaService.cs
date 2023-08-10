namespace Aggregator.Web.Api.Services;

public class AreaService : IAreaService
{
    private readonly GrpcSchool.AreaService.AreaServiceClient _client;
    private readonly ILogger<AreaService> _logger;

    public AreaService(GrpcSchool.AreaService.AreaServiceClient client, ILogger<AreaService> logger)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateAreaResponse> CreateAreaAsync(CreateAreaRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Grpc request create area");
        return await _client.CreateAreaAsync(request, new CallOptions { });
    }
}

