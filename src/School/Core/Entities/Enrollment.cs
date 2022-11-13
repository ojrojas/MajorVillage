namespace Core.Entities
{
    public class Enrollment
    {
        public Guid StudentId { get; set; }
        public Guid ElectiveYearId { get; set; }
        public ElectiveYear ElectiveYear { get; set; }

    }
}
