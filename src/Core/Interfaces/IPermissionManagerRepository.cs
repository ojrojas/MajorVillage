namespace MajorVillage.Core.Interfaces;

public interface IPermissionManagerRepository
{
    Task<PermissionManager> GetPermission(Guid typeUserId, CancellationToken cancellationToken);
    Task<PermissionAction> GetPermissionAction(Guid typeUserId, CancellationToken cancellationToken);
}
