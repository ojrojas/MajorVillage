namespace Core.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _repository;
    private readonly ILogger<UserService> _logger;

    public UserService(IGenericRepository<User> repository, ILogger<UserService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        CreateUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.UserCreated = await _repository.CreateAsync(request.User, cancellationToken);
        _logger.LogInformation($"Create record params {JsonSerializer.Serialize(request.User)}");
        return response;
    }

    public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        UpdateUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.UserUpdated = await _repository.UpdateAsync(request.User, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.User)}");
        return response;
    }

    public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        DeleteUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        var User = await _repository.GetByIdAsync(request.Id, cancellationToken);
        var deleted = await _repository.DeleteAsync(User, cancellationToken);
        response.UserDeleted = deleted != default ? true : false;
        _logger.LogInformation($"Delete record params {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async Task<GetAllUserResponse> GetAllUserAsync(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        GetAllUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        UserSpecifications specification = new UserSpecifications();
        response.Users = await _repository.ListAsync(specification, cancellationToken);
        _logger.LogInformation($"Get all records");
        return response;
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        GetUserByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.User = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get record by id {request.Id}");
        return response;
    }
}

