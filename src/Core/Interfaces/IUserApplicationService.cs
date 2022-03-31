namespace MajorVillage.Core.Interfaces;

public interface IUserApplicationService
{
    Task<CreateUserApplicationResponse> CreateUserApplication(CreateUserApplicationRequest request, CancellationToken cancellationToken);
    Task<LoginUserApplicationResponse> LoginUserApplication(LoginUserApplicationRequest request, CancellationToken cancellationToken);
}