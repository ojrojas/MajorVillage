
namespace MajorVillage.Core.Repositories;

public class TypeIdentificationRepository : ITypeIdentificationRepository
{
    private readonly IDapperRepository<TypeIdentification> _repository;
    public ILogger<TypeIdentificationRepository> _logger;

    public TypeIdentificationRepository(IDapperRepository<TypeIdentification> repository, ILogger<TypeIdentificationRepository> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<TypeIdentification>> GetAllIdentificationType(IPredicate predicate, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(predicate, cancellationToken);
    }

}