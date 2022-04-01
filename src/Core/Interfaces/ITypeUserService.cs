namespace MajorVillage.Core.Interfaces;

public interface ITypeUserService
{
    Task<GetAllTypeUserResponse> GetAllTypeUsers(GetAllTypeUsersRequest request, CancellationToken  cancellationToken);
}
