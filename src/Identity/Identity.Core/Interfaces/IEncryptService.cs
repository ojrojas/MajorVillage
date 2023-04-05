namespace Identity.Core.Interfaces;

public interface IEncryptService
{
    Task<string> Encrypt(string password, bool useHashing = true);
}
