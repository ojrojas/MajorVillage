namespace MajorVillage.Core.Interfaces;

public interface ITypeUserRepository
{
    Task<IEnumerable<TypeUser>> GetAllUserType(IPredicate predicate, CancellationToken cancellationToken);
}