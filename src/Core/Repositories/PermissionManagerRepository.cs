namespace MajorVillage.Core.Repositories;

public class PermissionManagerRepository : IPermissionManagerRepository
{
    private readonly IDapperRepository<PermissionManager> _repository;
    private readonly IDapperRepository<PermissionAction> _repositoryAction;
    private readonly ILogger<PermissionManagerRepository> _logger;

    public PermissionManagerRepository(IDapperRepository<PermissionManager> repository, IDapperRepository<PermissionAction> repositoryAction, ILogger<PermissionManagerRepository> logger)
    {
        _repository = repository;
        _repositoryAction = repositoryAction;
        _logger = logger;
    }

    public async Task<PermissionManager> GetPermission(Guid typeUserId, CancellationToken cancellationToken)
    {
        IPredicate predicate = Predicates.Field<PermissionManager>(e => e.Id, Operator.Eq, typeUserId);
        _logger.LogInformation("Get Permission Manager by TypeUserId", predicate.GetHashCode());
        return await _repository.GetByIdAsync(predicate, cancellationToken);
    }

    public async Task<PermissionAction> GetPermissionAction(Guid typeUserId, CancellationToken cancellationToken)
    {
        IPredicate predicate = Predicates.Field<PermissionManager>(e => e.Id, Operator.Eq, typeUserId);
        _logger.LogInformation("Get Permission Action by TypeUserId", predicate.GetHashCode());
        return await _repositoryAction.GetByIdAsync(predicate, cancellationToken);
    }
}