namespace MajorVillage.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _UserRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository UserRepository,
                       ILogger<UserService> logger)
    {
        _UserRepository = UserRepository;
        _logger = logger;
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var response = new GetUserByIdResponse(request.CorrelationId());
        _logger.LogInformation($"Get User by id, in request {request.CorrelationId()}");
        response.User = await _UserRepository.GetUserByIdAsync(request.Id, cancellationToken);
        return response;
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        CreateUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Create User, in request {request.CorrelationId()}");
        response.CreatedUser = await _UserRepository.CreateUserAsync(request.User, cancellationToken);
        return response;
    }

    public async Task<UpdateUserResponse> UpdateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        UpdateUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Update User, in request {request.CorrelationId()}");
        response.Updated = await _UserRepository.UpdateUserAsync(request.User, cancellationToken);
        return response;
    }

    public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        DeleteUserResponse response = new(request.CorrelationId());
        var newRequest = await _UserRepository.GetUserByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Delete User, in request {request.CorrelationId()}");
        response.Deleted = await _UserRepository.DeleteUserAsync(newRequest, cancellationToken);
        return response;
    }

    public async Task<ListUserResponse> ListUserAsync(ListUserRequest request, CancellationToken cancellationToken)
    {
        ListUserResponse response = new(request.CorrelationId());
        _logger.LogInformation($"List Users, in request {request.CorrelationId()}");
        response.ListUsers = await _UserRepository.ListUserAsync(cancellationToken);
        return response;
    }
}