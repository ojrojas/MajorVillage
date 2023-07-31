namespace Identity.Core.Services;

public class AttendantService : IAttendantService
{
    /// <summary>
    /// Generic repository instance type of Attendant
    /// </summary>
    private readonly AttendantRepository _repository;
    /// <summary>
    /// Logger instance type of Attendant Service
    /// </summary>
    private readonly ILoggerApplicationService<AttendantService> _logger;

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="repository">Repository instance Attendant</param>
    /// <param name="logger">Logger instance service</param>
    /// <exception cref="ArgumentNullException">Dependency null exception instances type repository and logger</exception>
    public AttendantService(AttendantRepository repository, ILoggerApplicationService<AttendantService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateAttendantResponse> CreateAttendantAsync(CreateAttendantRequest request, CancellationToken cancellationToken)
    {
        CreateAttendantResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create attendant request");
        response.AttendantCreated = await _repository.CreateAsync(request.Attendant, cancellationToken);
        _logger.LogInformation($"Create record params {JsonSerializer.Serialize(request.Attendant)}");
        return response;
    }

    public async ValueTask<DeleteAttendantResponse> DeleteAttendantAsync(DeleteAttendantRequest request, CancellationToken cancellationToken)
    {
        DeleteAttendantResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete attendant request");
        var Attendant = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.IsAttendantDeleted = await _repository.DeleteAsync(Attendant, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {JsonSerializer.Serialize(request.Id)}");
        return response;

    }

    public async ValueTask<GetAllAttendantResponse> GetAllAttendantAsync(GetAllAttendantRequest request, CancellationToken cancellationToken)
    {
        GetAllAttendantResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all attendants request");
        response.Attendants = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all records");
        return response;
    }

    public async ValueTask<GetAttendantByIdResponse> GetAttendantByIdAsync(GetAttendantByIdRequest request, CancellationToken cancellationToken)
    {
        GetAttendantByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get attendant by id request");
        response.Attendant = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get record by id params {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async ValueTask<UpdateAttendantResponse> UpdateAttendantAsync(UpdateAttendantRequest request, CancellationToken cancellationToken)
    {
        UpdateAttendantResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Update attendant request");
        response.TypeIdenticicationUpdated = await _repository.UpdateAsync(request.Attendant, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Attendant)}");
        return response;
    }
}

