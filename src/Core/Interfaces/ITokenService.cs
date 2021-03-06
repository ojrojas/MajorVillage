namespace MajorVillage.Core.Interfaces;

public interface ITokenService<T>
{
    Task<string> GetTokenAsync(T user);
}