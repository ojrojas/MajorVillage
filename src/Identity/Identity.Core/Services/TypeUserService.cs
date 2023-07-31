namespace Identity.Core.Services;

public class TypeUserService : ITypeUserService
{
    private readonly TypeUserRepository _repository;
    private readonly ILoggerApplicationService<TypeUserService> _logger;

    public TypeUserService(TypeUserRepository repository, ILoggerApplicationService<TypeUserService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateTypeUserResponse> CreateTypeUserAsync(CreateTypeUserRequest request, CancellationToken cancellationToken)
    {
        CreateTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create type user request");
        response.TypeUserCreated = await _repository.CreateAsync(request.TypeUser, cancellationToken);
        _logger.LogInformation($"Create record params {JsonSerializer.Serialize(request.TypeUser)}");
        return response;
    }

    public async ValueTask<UpdateTypeUserResponse> UpdateTypeUserAsync(UpdateTypeUserRequest request, CancellationToken cancellationToken)
    {
        UpdateTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Update type user request");
        response.TypeUserUpdated = await _repository.UpdateAsync(request.TypeUser, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.TypeUser)}");
        return response;
    }

    public async ValueTask<DeleteTypeUserResponse> DeleteTypeUserAsync(DeleteTypeUserRequest request, CancellationToken cancellationToken)
    {
        DeleteTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete type user request");
        var typeUser = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.IsTypeUserDeleted = await _repository.UpdateAsync(typeUser, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async ValueTask<GetAllTypeUserResponse> GetAllTypeUserAsync(GetAllTypeUserRequest request, CancellationToken cancellationToken)
    {
        GetAllTypeUserResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all type users");
        response.TypeUsers = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all records");
        return response;
    }

    public async ValueTask<GetTypeUserByIdResponse> GetTypeUserByIdAsync(GetTypeUserByIdRequest request, CancellationToken cancellationToken)
    {
        GetTypeUserByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get type user by id request");
        response.TypeUser = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get record by id {request.Id}");
        return response;
    }
}