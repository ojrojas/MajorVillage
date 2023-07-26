namespace Identity.Core.Services;

public class TypeIdentificationService : ITypeIdentificationService
{
    /// <summary>
    /// Generic repository instance type of TypeIdentification
    /// </summary>
    private readonly TypeIdentificationRepository _repository;
    /// <summary>
    /// Logger instance type of TypeIdentification Service
    /// </summary>
    private readonly ILoggerApplicationService<TypeIdentificationService> _logger;

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="repository">Repository instance TypeIdentification</param>
    /// <param name="logger">Logger instance service</param>
    /// <exception cref="ArgumentNullException">Dependency null exception instances type repository and logger</exception>
    public TypeIdentificationService(TypeIdentificationRepository repository, ILoggerApplicationService<TypeIdentificationService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateTypeIdentificationResponse> CreateTypeIdentificationAsync(CreateTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        CreateTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create type identification request");
        response.TypeIdentificationCreated = await _repository.CreateAsync(request.TypeIdentification, cancellationToken);
        _logger.LogInformation($"Create record params {JsonSerializer.Serialize(request.TypeIdentification)}");
        return response;
    }

    public async ValueTask<DeleteTypeIdentificationResponse> DeleteTypeIdentificationAsync(DeleteTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        DeleteTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete type identification request");
        var TypeIdentification = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.TypeIdentificationDeleted = await _repository.DeleteAsync(TypeIdentification, cancellationToken);
        _logger.LogInformation($"Delete record params {JsonSerializer.Serialize(request.Id)}");
        return response;

    }

    public async ValueTask<GetAllTypeIdentificationResponse> GetAllTypeIdentificationAsync(GetAllTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        GetAllTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all type identifications");
        response.TypeIdentifications = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all records");
        return response;
    }

    public async ValueTask<GetTypeIdentificationByIdResponse> GetTypeIdentificationByIdAsync(GetTypeIdentificationByIdRequest request, CancellationToken cancellationToken)
    {
        GetTypeIdentificationByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get type identificatio by id request");
        response.TypeIdentification = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get record by id params {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async ValueTask<UpdateTypeIdentificationResponse> UpdateTypeIdentificationAsync(UpdateTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        UpdateTypeIdentificationResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Update type identification request");
        response.TypeIdentificationUpdated = await _repository.UpdateAsync(request.TypeIdentification, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.TypeIdentification)}");
        return response;
    }
}

