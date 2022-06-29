namespace MajorVillage.Core.Interfaces;

public interface ITokenClaimService
{
    Task<string> GetTokenAsync(User user);
}
