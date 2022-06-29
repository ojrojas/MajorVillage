namespace MajorVillage.Core.Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly IUserApplicationRepository _repository;
    private readonly ILogger<UserApplication> _logger;
    private readonly ITokenClaimService _tokenClaim;
    private readonly IUserRepository _userRepository;

    public UserApplicationService(
        IUserApplicationRepository repository,
        ILogger<UserApplication> logger,
        ITokenClaimService tokenClaim,
        IUserRepository userRepository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _tokenClaim = tokenClaim ?? throw new ArgumentNullException(nameof(tokenClaim));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<CreateUserApplicationResponse> CreateUserApplication(CreateUserApplicationRequest request, CancellationToken cancellationToken)
    {
        CreateUserApplicationResponse response = new(request.CorrelationId());
        response.Id = await _repository.CreateUserApplication(request.userApplication, cancellationToken);
        return response;
    }

    public async Task<LoginUserApplicationResponse> LoginUserApplication(LoginUserApplicationRequest request, CancellationToken cancellationToken)
    {
        LoginUserApplicationResponse response = new(request.CorrelationId());
        var userApplication = await _repository.LoginAsync(new() { Password = request.Password, UserName = request.UserName }, cancellationToken);
        User user = default;
        if (userApplication is not null)
            user = await _userRepository.GetUserByIdAsync(userApplication.UserId, cancellationToken);
        response.Token = await _tokenClaim.GetTokenAsync(user);
        return response;
    }
}