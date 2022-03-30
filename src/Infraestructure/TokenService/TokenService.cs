namespace MajorVillage.Infraestructure.TokenService;

public class TokenService<T>
{
    private readonly ILogger<TokenService<T>> _logger;
    private readonly TokenOption _options;

    public TokenService(ILogger<TokenService<T>> logger, IOptions<TokenOption> options)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    // public Task<string> GetJwtToken(UserApplication userApplication)
    // {

    // }
}