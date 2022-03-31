namespace MajorVillage.Core.Interfaces;

public interface IUserApplicationRepository
{
    Task<Guid> CreateUserApplication(UserApplication userApplication, CancellationToken cancellationToken);
    Task<UserApplication> LoginAsync(UserApplication userApplication, CancellationToken cancellationToken);
}