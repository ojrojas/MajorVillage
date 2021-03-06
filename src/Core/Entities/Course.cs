namespace MajorVillage.Core.Entities;

public class Course: BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public Guid ElectiveYearId { get; set; }
}