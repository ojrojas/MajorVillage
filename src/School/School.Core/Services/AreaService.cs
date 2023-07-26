namespace School.Core.Services;

public class AreaService 
{
    private readonly AreaRepository _repository;
    private readonly ILogger<AreaService> _logger;

    public AreaService(AreaRepository repository, ILogger<AreaService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateAreaResponse> CreateAsync(CreateAreaRequest request, CancellationToken cancellationToken)
    {
        CreateAreaResponse response = new(request.CorrelationId());
        _logger.LogInformation($"[{response.CorrelationId()}] - Create area request");


        return response;
    }
}

