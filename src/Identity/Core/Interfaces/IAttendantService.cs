namespace Core.Interfaces
{
    public interface IAttendantService
    {
        Task<CreateAttendantResponse> CreateAttendantAsync(CreateAttendantRequest request, CancellationToken cancellationToken);
        Task<DeleteAttendantResponse> DeleteAttendantAsync(DeleteAttendantRequest request, CancellationToken cancellationToken);
        Task<GetAllAttendantResponse> GetAllAttendantAsync(GetAllAttendantRequest request, CancellationToken cancellationToken);
        Task<GetAttendantByIdResponse> GetAttendantByIdAsync(GetAttendantByIdRequest request, CancellationToken cancellationToken);
        Task<UpdateAttendantResponse> UpdateAttendantAsync(UpdateAttendantRequest request, CancellationToken cancellationToken);
    }
}