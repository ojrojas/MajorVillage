namespace MajorVillage.Core.Interfaces;

public interface ITypeIdentificationRepository
{
    Task<IEnumerable<TypeIdentification>> GetAllIdentificationType(IPredicate predicate, CancellationToken cancellationToken);
}