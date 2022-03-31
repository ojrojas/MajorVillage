namespace MajorVillage.Core.Services;

public class TypeUserService : ITypeUserService
{
    private readonly ITypeUserRepository _typeUserRepository;
    private readonly ILogger<TypeUserService> _logger;

    public TypeUserService(ITypeUserRepository typeUserRepository, ILogger<TypeUserService> logger)
    {
        _typeUserRepository = typeUserRepository ?? throw new ArgumentNullException(nameof(typeUserRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<TypeUser>> GetAllTypeUsers(IPredicate predicate, CancellationToken  cancellationToken)
    {
        return await _typeUserRepository.GetAllUserType(predicate, cancellationToken);
    }
}