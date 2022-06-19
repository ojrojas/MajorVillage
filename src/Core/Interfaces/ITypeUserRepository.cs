namespace MajorVillage.Core.Interfaces;

public interface ITypeUserRepository
{
    Task<IEnumerable<TypeUser>> GetAllUserType(CancellationToken cancellationToken);
}