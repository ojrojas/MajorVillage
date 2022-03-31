namespace MajorVillage.Core.Interfaces;

public interface ITypeIdentificationService
{
    Task<IEnumerable<TypeIdentification>> GetAllTypeIdentifications(IPredicate predicate, CancellationToken cancellationToken);
}
