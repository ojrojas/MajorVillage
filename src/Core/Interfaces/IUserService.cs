namespace MajorVillage.Core.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken);
        Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken);
        Task<ListUserResponse> ListUserAsync(ListUserRequest request, CancellationToken cancellationToken);
        Task<UpdateUserResponse> UpdateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
    }
}