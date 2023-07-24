namespace Identity.Core.Interfaces;

public interface ITypeUserService
{
    ValueTask<CreateTypeUserResponse> CreateTypeUserAsync(CreateTypeUserRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteTypeUserResponse> DeleteTypeUserAsync(DeleteTypeUserRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllTypeUserResponse> GetAllTypeUserAsync(GetAllTypeUserRequest request, CancellationToken cancellationToken);
    ValueTask<GetTypeUserByIdResponse> GetTypeUserByIdAsync(GetTypeUserByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateTypeUserResponse> UpdateTypeUserAsync(UpdateTypeUserRequest request, CancellationToken cancellationToken);
}