namespace MajorVillage.Core.Entities;

public class Enrollment : BaseEntity
{
    public ElectiveYear ElectiveYear { get; set; }
    public Guid ElectiveYearId { get; set; }
    public User User { get; set; }
    public UserApplication UserApplication { get; set; }
}