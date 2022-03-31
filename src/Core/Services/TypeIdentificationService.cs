namespace MajorVillage.Core.Services;

public class TypeIdentificationService : ITypeIdentificationService
{
    private readonly ITypeIdentificationRepository _typeIdentificationRepository;
    private readonly ILogger<TypeIdentificationService> _logger;

    public TypeIdentificationService(ITypeIdentificationRepository typeIdentificationRepository, ILogger<TypeIdentificationService> logger)
    {
        _typeIdentificationRepository = typeIdentificationRepository ?? throw new ArgumentNullException(nameof(typeIdentificationRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<TypeIdentification>> GetAllTypeIdentifications(IPredicate predicate, CancellationToken cancellationToken)
    {
        return await _typeIdentificationRepository.GetAllIdentificationType(predicate, cancellationToken);
    }
}