namespace MajorVillage.Core.Interfaces;

public interface IPermissionManagerService
{
    Task<PermissionManagerResponse> GetPermission(PermissionManagerRequest request, CancellationToken cancellationToken);
    Task<PermissionManagerActionResponse> GetPermissionAction(PermissionManagerActionRequest request, CancellationToken cancellationToken);
}