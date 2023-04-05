namespace Identity.Core.Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly UserApplicationRepository _repository;
    private readonly IEncryptService _encryptService;
    private readonly ILogger<UserApplicationService> _logger;
    private readonly ITokenService<User> _tokenService;

    public UserApplicationService(UserApplicationRepository repository, IEncryptService encryptService, ILogger<UserApplicationService> logger, ITokenService<User> tokenService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _encryptService = encryptService ?? throw new ArgumentNullException(nameof(encryptService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    public async Task<CreateUserApplicationResponse> CreateUserApplicationAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken)
    {
        CreateUserApplicationResponse response = new(request.CorrelationId());
        if (request.UserApplication is null) throw new ArgumentNullException(nameof(request.UserApplication));
        request.UserApplication.UserName = request.UserApplication.UserName.ToLowerInvariant();
        request.UserApplication.Password = await _encryptService.Encrypt(request.UserApplication.Password);
        _logger.LogInformation($"Create user application {JsonSerializer.Serialize(request.UserApplication)}");
        var created = await _repository.CreateAsync(request.UserApplication, cancellationToken);
        response.UserApplicationCreated = created is not null;
        return response;
    }

    public async Task<DeleteUserApplicationResponse> DeleteUserApplicationAsync(DeleteUserApplicationRequest request, CancellationToken cancellationToken)
    {
        DeleteUserApplicationResponse response = new(request.CorrelationId());
        if (request.Id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(request.Id));
        UserApplication userApplication = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.UserApplicationDeleted = await _repository.DeleteAsync(userApplication, cancellationToken);
        return response;
    }

    public async Task<GetAllUserApplicationResponse> GetAllUserApplicationsAsync(GetAllUserApplicationRequest request, CancellationToken cancellationToken)
    {
        GetAllUserApplicationResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Get all user applications request");
        response.UserApplications = await _repository.ListAsync(cancellationToken);
        return response;
    }

    public async Task<LoginUserApplicationResponse> LoginAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken)
    {
        LoginUserApplicationResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Encrypt password and get user by login");
        request.Password = await _encryptService.Encrypt(request.Password);
        request.UserName = request.UserName.ToLowerInvariant();
        UserApplicationSpecifications specification = new(request.UserName, request.Password);
        var result = await _repository.FirstOrDefaultAsync(specification, cancellationToken);
        if (result is not null)
            response.Token = await _tokenService.GetTokenAsync(result.User);
        return response;
    }
}