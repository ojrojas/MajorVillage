namespace MajorVillage.Core.Interfaces;

public interface IEncryptPassFunctionality
{
    Task<string> Encrypt(string password, bool useHashing = true);
}