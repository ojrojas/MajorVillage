namespace Core.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SurName { get; set; }
        public string Identification { get; set; }
        public DateTime BirthDate { get; set; }
        public TypeIdentification? TypeIdentification { get; set; }
        public Guid TypeIdentificationId { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public TypeUser? TypeUser { get; set; }
        public Guid TypeUserId { get; set; }
    }
}
