namespace Identity.Core.Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly UserApplicationRepository _repository;
    private readonly ILogger<UserApplicationService> _logger;
    private readonly UserManager<UserApplication> _userManager;
    private readonly SignInManager<UserApplication> _signInManager;

    private readonly IPasswordHasher<UserApplication> _passwordHasher = new PasswordHasher<UserApplication>();

    public UserApplicationService(UserApplicationRepository repository,
                                  ILogger<UserApplicationService> logger,
                                  UserManager<UserApplication> userManager,
                                  SignInManager<UserApplication> signInManager)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    public async Task<CreateUserApplicationResponse> CreateUserApplicationAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken)
    {
        CreateUserApplicationResponse response = new(request.CorrelationId());
        if (request.UserApplication is null) throw new ArgumentNullException(nameof(request.UserApplication));
        ArgumentNullException.ThrowIfNull(request.UserApplication.PasswordHash);
        ArgumentNullException.ThrowIfNull(request.UserApplication.UserName);
        request.UserApplication.UserName = request.UserApplication.UserName.ToLowerInvariant();
        request.UserApplication.PasswordHash = _passwordHasher.HashPassword(request.UserApplication, request.UserApplication.PasswordHash);
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
        response.Token = "Do not get token response";
        _logger.LogInformation($"Encrypt password and get user by login");
        request.UserName = request.UserName.ToLowerInvariant();
        UserApplicationSpecifications specification = new(request.UserName);
        var result = await _repository.FirstOrDefaultAsync(specification, cancellationToken);
        if (result is not null)
        {
            var token = await _userManager.CheckPasswordAsync(result, request.Password);
            if (token)
            {
                await _signInManager.SignInAsync(result, true);
                response.Token = "Signin successful";
            }
        }

        return response;
    }
}