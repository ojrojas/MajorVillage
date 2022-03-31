namespace MajorVillage.Core.Interfaces;

public interface ITypeUserService
{
    Task<IEnumerable<TypeUser>> GetAllTypeUsers(IPredicate predicate, CancellationToken cancellationToken);
}
