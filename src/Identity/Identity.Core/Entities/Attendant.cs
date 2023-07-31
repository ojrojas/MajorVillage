namespace Identity.Core.Entities;

public class Attendant : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Identification { get; set; } = null!;
    public TypeIdentification TypeIdentification { get; set; } = null!;
    public Guid TypeIdentificationId { get; set; }
    public string UserId { get; set; } = null!;
}