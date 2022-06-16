namespace MajorVillage.Core.Entities;

public class Enrollment : BaseEntity
{
    public Guid ElectiveYearId { get; set; }
    public Guid UserId {get;set; }
    public Guid UserApplicationId {get;set;}
}