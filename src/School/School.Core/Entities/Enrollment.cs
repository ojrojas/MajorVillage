namespace School.Core.Entities;

public class Enrollment : BaseEntity, IAggregateRoot
{
    // User is same StudentId from entity user of Identity
    public Guid StudentId { get; set; }
    public Guid AttendantId { get; set; }
    public bool IsApproved { get; set; }
    public ElectiveYear? ElectiveYear { get; set; }
    public Guid ElectiveYearId { get; set; }
    public EnrollmentStatus EnrollmentStatus { get; set; }
}

public enum EnrollmentStatus
{
    PreEnrolled = 0,
    Enrolled,
    Suspended,
    Cancelled,
    Removed
}
