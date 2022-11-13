namespace Core.Interfaces
{
    public interface IUserApplicationService
    {
        Task<CreateUserApplicationResponse> CreateUserApplicationAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken);
        Task<GetAllUserApplicationResponse> GetAllUserApplicationsAsync(GetAllUserApplicationRequest request, CancellationToken cancellationToken);
        Task<LoginUserApplicationResponse> LoginAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken);
        Task<DeleteUserApplicationResponse> DeleteUserApplicationAsync(DeleteUserApplicationRequest request, CancellationToken cancellationToken);
    }
}