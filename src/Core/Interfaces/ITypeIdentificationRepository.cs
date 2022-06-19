namespace MajorVillage.Core.Interfaces;

public interface ITypeIdentificationRepository
{
    Task<IEnumerable<TypeIdentification>> GetAllIdentificationType(CancellationToken cancellationToken);
}