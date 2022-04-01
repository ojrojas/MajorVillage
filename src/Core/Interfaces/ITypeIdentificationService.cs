namespace MajorVillage.Core.Interfaces;

public interface ITypeIdentificationService
{
    Task<GetAllTypeIdentificationResponse> GetAllTypeIdentifications(GetAllTypeIdentificationRequest request, CancellationToken cancellationToken);
}
