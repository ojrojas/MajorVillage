namespace Identity.Core.Interfaces;

public interface ITypeIdentificationService
{
    Task<CreateTypeIdentificationResponse> CreateTypeIdentificationAsync(CreateTypeIdentificationRequest request, CancellationToken cancellationToken);
    Task<DeleteTypeIdentificationResponse> DeleteTypeIdentificationAsync(DeleteTypeIdentificationRequest request, CancellationToken cancellationToken);
    Task<GetAllTypeIdentificationResponse> GetAllTypeIdentificationAsync(GetAllTypeIdentificationRequest request, CancellationToken cancellationToken);
    Task<GetTypeIdentificationByIdResponse> GetTypeIdentificationByIdAsync(GetTypeIdentificationByIdRequest request, CancellationToken cancellationToken);
    Task<UpdateTypeIdentificationResponse> UpdateTypeIdentificationAsync(UpdateTypeIdentificationRequest request, CancellationToken cancellationToken);
}