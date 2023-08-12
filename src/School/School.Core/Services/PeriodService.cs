namespace School.Core.Services;

public class PeriodService : IPeriodService
{
    private readonly PeriodRepository _repository;
    private readonly ILoggerApplicationService<PeriodService> _logger;
    private readonly IMapper _mapper;

    public PeriodService(PeriodRepository repository, ILoggerApplicationService<PeriodService> logger, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request, CancellationToken cancellationToken)
    {
        CreatePeriodResponse response = new();
        _logger.LogInformation(request.Correlationid, "Create Period request");
        response.Periodcreated = _mapper.Map<GrpcSchool.Period>(await _repository.CreateAsync(_mapper.Map<Period>(request.Period), cancellationToken));
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Period)}");

        return response;
    }

    public async ValueTask<UpdatePeriodResponse> UpdatePeriodAsync(UpdatePeriodRequest request, CancellationToken cancellationToken)
    {
        UpdatePeriodResponse response = new();
        _logger.LogInformation(request.Correlationid, "Update Period request");
        response.Periodupdated = _mapper.Map<GrpcSchool.Period>(await _repository.UpdateAsync(_mapper.Map<Period>(request.Period), cancellationToken));
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Period)}");

        return response;
    }

    public async ValueTask<DeletePeriodResponse> DeletePeriodAsync(DeletePeriodRequest request, CancellationToken cancellationToken)
    {
        DeletePeriodResponse response = new();
        _logger.LogInformation(request.Correlationid, "Delete Period request");
        var PeriodToDelete = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        response.Isperioddeleted = await _repository.DeleteAsync(PeriodToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetPeriodByIdResponse> GetPeriodByIdAsync(GetPeriodByIdRequest request, CancellationToken cancellationToken)
    {
        GetPeriodByIdResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get Period by id request");
        response.Period = _mapper.Map<GrpcSchool.Period>(await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Get by id Period params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllPeriodsResponse> GetAllPeriodsAsync(GetAllPeriodsRequest request, CancellationToken cancellationToken)
    {
        GetAllPeriodsResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all Periods request");
        response.Periods.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<Period, GrpcSchool.Period>(_mapper));
        _logger.LogInformation($"Get all Periods response count: {response.Periods.Count()}");

        return response;
    }
}

