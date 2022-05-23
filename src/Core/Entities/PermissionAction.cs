namespace MajorVillage.Core.Entities;

public class PermissionAction : BaseEntity
{
    public Guid PermissionManagerId { get; set; }
    public bool EditAllow { get; set; }
    public bool CreateAllow { get; set; }
    public bool UpdateAllow { get; set; }
}