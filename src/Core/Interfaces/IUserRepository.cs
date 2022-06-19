namespace MajorVillage.Core.Interfaces;

public interface IUserRepository
{
    Task<dynamic> CreateUserAsync(User User, CancellationToken cancellationToken);
    Task<dynamic> CreateUsersAsync(IEnumerable<User> Users, IDbTransaction transaction, int timeOut, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(User User, CancellationToken cancellationToken);
    Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<User>> ListUserAsync(CancellationToken cancellationToken);
    Task<bool> UpdateUserAsync(User User, CancellationToken cancellationToken);
}
