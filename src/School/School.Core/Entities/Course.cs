namespace School.Core.Entities;

public class Course : BaseEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid CourseDirectorId { get; set; }
    public Guid CurrentPeriodId { get; set; }
    public CourseStatus CourseStatus { get; set; }
    public ElectiveYear? ElectiveYear { get; set; }
    public Guid ElectiveYearId { get; set; }
    public ClassRoom? ClassRoom { get; set; }
    public Guid ClassRoomId { get; set; }

    public IEnumerable<Student>? Students { get; set; }
    public IEnumerable<Period>? Periods { get; set; }
}

public enum CourseStatus
{
    Available,
    UnAvailable
}
