namespace School.Core.Services;

public class AreaService : IAreaService
{
    private readonly AreaRepository _repository;
    private readonly ILoggerApplicationService<AreaService> _logger;

    public AreaService(AreaRepository repository, ILoggerApplicationService<AreaService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateAreaResponse> CreateAreaAsync(CreateAreaRequest request, CancellationToken cancellationToken)
    {
        CreateAreaResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create area request");
        response.AreaCreated = await _repository.CreateAsync(request.Area, cancellationToken);
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Area)}");

        return response;
    }

    public async ValueTask<UpdateAreaResponse> UpdateAreaAsync(UpdateAreaRequest request, CancellationToken cancellationToken)
    {
        UpdateAreaResponse response = new UpdateAreaResponse(request.CorrelationId());
        _logger.LogInformation(response, "Update area request");
        response.AreaUpdated = await _repository.UpdateAsync(request.Area, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Area)}");

        return response;
    }

    public async ValueTask<DeleteAreaResponse> DeleteAreaAsync(DeleteAreaRequest request, CancellationToken cancellationToken)
    {
        DeleteAreaResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete area request");
        var areaToDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.IsAreaDeleted = await _repository.DeleteAsync(areaToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetAreaByIdResponse> GetAreaByIdAsync(GetAreaByIdRequest request, CancellationToken cancellationToken)
    {
        GetAreaByIdResponse response = new GetAreaByIdResponse(request.CorrelationId());
        _logger.LogInformation(response, "Get area by id request");
        response.Area = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get by id area params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllAreasResponse> GetAllAreasAsync(GetAllAreasRequest request, CancellationToken cancellationToken)
    {
        GetAllAreasResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all areas request");
        response.Areas = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all areas response count: {response.Areas.Count()}");

        return response;
    }
}