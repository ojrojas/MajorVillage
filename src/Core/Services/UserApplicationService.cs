namespace MajorVillage.Core.Services;



public class UserApplicationService : IUserApplicationService
{
    private readonly IUserApplicationRepository _repository;
    private readonly ILogger<UserApplication> _logger;

    public UserApplicationService(IUserApplicationRepository repository, ILogger<UserApplication> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<CreateUserApplicationResponse> CreateUserApplication(CreateUserApplicationRequest request, CancellationToken cancellationToken)
    {
        CreateUserApplicationResponse response = new(request.CorrelationId());
        response.applicationUserDto.Id = await _repository.CreateUserApplication(request.userApplicationDto, cancellationToken);
        return response;
    }

    public async Task<LoginUserApplicationResponse> LoginUserApplication(LoginUserApplicationRequest request, CancellationToken cancellationToken)
    {
        LoginUserApplicationResponse response = new(request.CorrelationId());
        response.UserApplicationDto = await _repository.LoginAsync(new() {Password = request.Password, UserName = request.UserName}, cancellationToken);
        return response;
    }
}