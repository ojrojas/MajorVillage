namespace MajorVillage.Infraestructure.Encrypt;

public class EncryptPassFunctionality : IEncryptPassFunctionality
{
    private readonly ILogger<EncryptPassFunctionality> _logger;
    private readonly EncryptOption _options;

    public EncryptPassFunctionality(IOptions<EncryptOption> options, ILogger<EncryptPassFunctionality> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options.Value ?? throw new InvalidCastException(nameof(options));
    }

    public async Task<string> Encrypt(string password, bool useHashing = true)
    {
        try
        {
            _logger.LogInformation($"Encrypt password options encryptation options");
            var encrypted = KeyDerivation.Pbkdf2(password,
                                                 Encoding.UTF8.GetBytes(_options.Salt),
                                                 KeyDerivationPrf.HMACSHA512,
                                                 _options.Iterations,
                                                 _options.SizeKey);

            await Task.Yield();

            return Encoding.UTF8.GetString(encrypted);
        }
        catch (Exception ex)
        {
            await Task.Yield();
            _logger.LogError("Encrypt fail password result null", ex.Message);
            return null;
        }
    }
}