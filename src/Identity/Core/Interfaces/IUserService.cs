namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken);
        Task<GetAllUserResponse> GetAllUserAsync(GetAllUserRequest request, CancellationToken cancellationToken);
        Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken);
        Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    }
}