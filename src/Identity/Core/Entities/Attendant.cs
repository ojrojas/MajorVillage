namespace Core.Entities
{
    public class Attendant : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public TypeIdentification TypeIdentification { get; set; }
        public Guid TypeIdentificationId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
