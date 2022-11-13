namespace Core.Interfaces
{
    public interface ITypeUserService
    {
        Task<CreateTypeUserResponse> CreateTypeUserAsync(CreateTypeUserRequest request, CancellationToken cancellationToken);
        Task<DeleteTypeUserResponse> DeleteTypeUserAsync(DeleteTypeUserRequest request, CancellationToken cancellationToken);
        Task<GetAllTypeUserResponse> GetAllTypeUserAsync(GetAllTypeUserRequest request, CancellationToken cancellationToken);
        Task<GetTypeUserByIdResponse> GetTypeUserByIdAsync(GetTypeUserByIdRequest request, CancellationToken cancellationToken);
        Task<UpdateTypeUserResponse> UpdateTypeUserAsync(UpdateTypeUserRequest request, CancellationToken cancellationToken);
    }
}