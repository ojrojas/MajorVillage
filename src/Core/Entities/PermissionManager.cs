namespace MajorVillage.Core.Entities;
public class PermissionManager : BaseEntity
{
    public Guid TypeUser { get; set; }
    public string Page { get; set; }
    public bool Allow { get; set; }
}

