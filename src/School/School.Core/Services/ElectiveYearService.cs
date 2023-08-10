namespace School.Core.Services;

public class ElectiveYearService //: IElectiveYearService
{
    private readonly ILogger<ElectiveYearService> _logger;
    private readonly ElectiveYearRepository _repository;

    public ElectiveYearService(ILogger<ElectiveYearService> logger, ElectiveYearRepository repository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    //public async ValueTask<CreateElectiveYearResponse> CreateElectiveYearAsync(CreateElectiveYearRequest request, CancellationToken cancellationToken)
    //{
    //    CreateElectiveYearResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Create ElectiveYear request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.ElectiveYear)}");
    //    response.ElectiveYearCreated = await _repository.CreateAsync(request.ElectiveYear, cancellationToken);
    //    return response;
    //}

    //public async ValueTask<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElctiveYearRequest request, CancellationToken cancellationToken)
    //{
    //    UpdateElectiveYearResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Update ElectiveYear request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.ElectiveYear)}");
    //    response.ElectiveYearUpdated = await _repository.UpdateAsync(request.ElectiveYear, cancellationToken);
    //    return response;
    //}

    //public async ValueTask<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CancellationToken cancellationToken)
    //{
    //    DeleteElectiveYearResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Delete ElectiveYear request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.Id)}");
    //    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
    //    response.ElectiveYearDeleted = await _repository.DeleteAsync(entity, cancellationToken);
    //    return response;
    //}

    //public async ValueTask<GetAllElectiveYearResponse> GetAllElectiveYearsAsync(GetAllElectiveYearRequest request, CancellationToken cancellationToken)
    //{
    //    GetAllElectiveYearResponse response = new(request.CorrelationId());
    //    _logger.LogInformation($"Get all ElectiveYears request id: {response.CorrelationId}");
    //    response.ElectiveYears = await _repository.ListAsync(cancellationToken);
    //    return response;
    //}
}

