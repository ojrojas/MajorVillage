namespace School.Core.Services;

public class PeriodService 
{
    private readonly PeriodRepository _repository;
    private readonly ILoggerApplicationService<PeriodService> _logger;

    public PeriodService(PeriodRepository repository, ILoggerApplicationService<PeriodService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request, CancellationToken cancellationToken)
    {
        CreatePeriodResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create Period request");
        response.PeriodCreated = await _repository.CreateAsync(request.Period, cancellationToken);
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Period)}");

        return response;
    }

    public async ValueTask<UpdatePeriodResponse> UpdatePeriodAsync(UpdatePeriodRequest request, CancellationToken cancellationToken)
    {
        UpdatePeriodResponse response = new UpdatePeriodResponse(request.CorrelationId());
        _logger.LogInformation(response, "Update Period request");
        response.PeriodUpdated = await _repository.UpdateAsync(request.Period, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Period)}");

        return response;
    }

    public async ValueTask<DeletePeriodResponse> DeletePeriodAsync(DeletePeriodRequest request, CancellationToken cancellationToken)
    {
        DeletePeriodResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete Period request");
        var PeriodToDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.IsPeriodDeleted = await _repository.DeleteAsync(PeriodToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetPeriodByIdResponse> GetPeriodByIdAsync(GetPeriodByIdRequest request, CancellationToken cancellationToken)
    {
        GetPeriodByIdResponse response = new GetPeriodByIdResponse(request.CorrelationId());
        _logger.LogInformation(response, "Get Period by id request");
        response.Period = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get by id Period params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllPeriodsResponse> GetAllPeriodsAsync(GetAllPeriodsRequest request, CancellationToken cancellationToken)
    {
        GetAllPeriodsResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all Periods request");
        response.Periods = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all Periods response count: {response.Periods.Count()}");

        return response;
    }
}

