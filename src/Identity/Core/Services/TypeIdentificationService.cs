namespace Core.Services;

public class TypeIdentificationService : ITypeIdentificationService
{
    /// <summary>
    /// Generic repository instance type of TypeIdentification
    /// </summary>
    private readonly IGenericRepository<TypeIdentification> _repository;
    /// <summary>
    /// Logger instance type of TypeIdentification Service
    /// </summary>
    private readonly ILogger<TypeIdentificationService> _logger;

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="repository">Repository instance TypeIdentification</param>
    /// <param name="logger">Logger instance service</param>
    /// <exception cref="ArgumentNullException">Dependency null exception instances type repository and logger</exception>
    public TypeIdentificationService(IGenericRepository<TypeIdentification> repository, ILogger<TypeIdentificationService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateTypeIdentificationResponse> CreateTypeIdentificationAsync(CreateTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        CreateTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeIdentificationCreated = await _repository.CreateAsync(request.TypeIdentification, cancellationToken);
        _logger.LogInformation($"Create record params {JsonSerializer.Serialize(request.TypeIdentification)}");
        return response;
    }

    public async Task<DeleteTypeIdentificationResponse> DeleteTypeIdentificationAsync(DeleteTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        DeleteTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        var TypeIdentification = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.TypeIdentificationDeleted = await _repository.DeleteAsync(TypeIdentification, cancellationToken);
        _logger.LogInformation($"Delete record params {JsonSerializer.Serialize(request.Id)}");
        return response;

    }

    public async Task<GetAllTypeIdentificationResponse> GetAllTypeIdentificationAsync(GetAllTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        GetAllTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeIdentifications = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all records");
        return response;
    }

    public async Task<GetTypeIdentificationByIdResponse> GetTypeIdentificationByIdAsync(GetTypeIdentificationByIdRequest request, CancellationToken cancellationToken)
    {
        GetTypeIdentificationByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeIdentification = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get record by id params {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async Task<UpdateTypeIdentificationResponse> UpdateTypeIdentificationAsync(UpdateTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        UpdateTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeIdentificationUpdated = await _repository.UpdateAsync(request.TypeIdentification, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.TypeIdentification)}");
        return response;
    }
}

