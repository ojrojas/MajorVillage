namespace MajorVillage.Core.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDapperRepository<User> _repository;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(IDapperRepository<User> repository,
                          ILogger<UserRepository> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<dynamic> CreateUserAsync(User User, CancellationToken cancellationToken)
    {
        return await _repository.InsertAsync(User, cancellationToken);
    }

    public async Task<dynamic> CreateUsersAsync(IEnumerable<User> Users, IDbTransaction transaction, int timeOut, CancellationToken cancellationToken)
    {
        return await _repository.InsertsAsync(Users, cancellationToken, transaction, timeOut);
    }

    public async Task<bool> DeleteUserAsync(User User, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(User, cancellationToken);
    }

    public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var predicate = Predicates.Field<User>(s => s.Id, Operator.Eq, id);
        return await _repository.GetByIdAsync(predicate, cancellationToken);
    }

    public async Task<IEnumerable<User>> ListUserAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(null, cancellationToken);
    }

    public async Task<bool> UpdateUserAsync(User User, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAsync(User, cancellationToken, null, default);
    }
}