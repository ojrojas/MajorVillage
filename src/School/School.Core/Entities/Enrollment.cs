namespace School.Core.Entities;

public class Enrollment: BaseEntity, IAggregateRoot
{
    // User is same userId from entity user of Identity
    public Guid StudentId { get; set; }
    public Guid ElectiveYearId { get; set; }
    public ElectiveYear ElectiveYear { get; set; }
    public bool IsApproved { get; set; }
}