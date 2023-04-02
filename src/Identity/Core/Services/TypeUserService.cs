namespace Core.Services;

public class TypeUserService : ITypeUserService
{
    private readonly TypeUserRepository _repository;
    private readonly ILogger<TypeUserService> _logger;

    public TypeUserService(TypeUserRepository repository, ILogger<TypeUserService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateTypeUserResponse> CreateTypeUserAsync(CreateTypeUserRequest request, CancellationToken cancellationToken)
    {
        CreateTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeUserCreated = await _repository.CreateAsync(request.TypeUser, cancellationToken);
        _logger.LogInformation($"Create record params {JsonSerializer.Serialize(request.TypeUser)}");
        return response;
    }

    public async Task<UpdateTypeUserResponse> UpdateTypeUserAsync(UpdateTypeUserRequest request, CancellationToken cancellationToken)
    {
        UpdateTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeUserUpdated = await _repository.UpdateAsync(request.TypeUser, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.TypeUser)}");
        return response;
    }

    public async Task<DeleteTypeUserResponse> DeleteTypeUserAsync(DeleteTypeUserRequest request, CancellationToken cancellationToken)
    {
        DeleteTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        var typeUser = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.TypeUserDeleted = await _repository.UpdateAsync(typeUser, cancellationToken);
        _logger.LogInformation($"Delete record params {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async Task<GetAllTypeUserResponse> GetAllTypeUserAsync(GetAllTypeUserRequest request, CancellationToken cancellationToken)
    {
        GetAllTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeUsers = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all records");
        return response;
    }

    public async Task<GetTypeUserByIdResponse> GetTypeUserByIdAsync(GetTypeUserByIdRequest request, CancellationToken cancellationToken)
    {
        GetTypeUserByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.TypeUser = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get record by id {request.Id}");
        return response;
    }
}