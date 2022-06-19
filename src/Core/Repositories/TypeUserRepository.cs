namespace MajorVillage.Core.Repositories;

public class TypeUserRepository : ITypeUserRepository
{
    private readonly IDapperRepository<TypeUser> _repository;
    public ILogger<TypeUserRepository> _logger;

    public TypeUserRepository(IDapperRepository<TypeUser> repository,
                              ILogger<TypeUserRepository> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<TypeUser>> GetAllUserType(CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(null, cancellationToken);
    }

}