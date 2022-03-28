
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
        byte[] saltBytes = Encoding.UTF8.GetBytes(_options.Salt);
        byte[] passwordToEncrypt = Encoding.UTF8.GetBytes(password);
        var sha512 = SHA512.Create();
        passwordToEncrypt = sha512.ComputeHash(passwordToEncrypt);
      
        return Encoding.UTF8.GetString(passwordToEncrypt);
    }
}