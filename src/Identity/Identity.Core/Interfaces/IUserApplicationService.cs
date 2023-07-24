namespace Identity.Core.Interfaces;

public interface IUserApplicationService
{
    ValueTask<CreateUserApplicationResponse> CreateUserApplicationAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllUserApplicationResponse> GetAllUserApplicationsAsync(GetAllUserApplicationRequest request, CancellationToken cancellationToken);
    ValueTask<IResult> LoginAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteUserApplicationResponse> DeleteUserApplicationAsync(DeleteUserApplicationRequest request, CancellationToken cancellationToken);
    ValueTask<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateUserApplicationResponse> UpdateUserApplicationAsync(UpdateUserApplicationRequest request, CancellationToken cancellationToken);
}