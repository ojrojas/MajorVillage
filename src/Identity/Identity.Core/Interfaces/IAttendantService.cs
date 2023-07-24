namespace Identity.Core.Interfaces;

public interface IAttendantService
{
    ValueTask<CreateAttendantResponse> CreateAttendantAsync(CreateAttendantRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteAttendantResponse> DeleteAttendantAsync(DeleteAttendantRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllAttendantResponse> GetAllAttendantAsync(GetAllAttendantRequest request, CancellationToken cancellationToken);
    ValueTask<GetAttendantByIdResponse> GetAttendantByIdAsync(GetAttendantByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateAttendantResponse> UpdateAttendantAsync(UpdateAttendantRequest request, CancellationToken cancellationToken);
}