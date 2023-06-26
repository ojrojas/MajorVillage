namespace Identity.Core.Entities;

public class UserApplication : IdentityUser, IAggregateRoot
{
    [Required]
    public string Name { get; set; }
    public string? MiddleName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? SurName { get; set; }
    [Required]
    public string Identification { get; set; }
    [Required] public DateTime BirthDate { get; set; }
    public TypeIdentification? TypeIdentification { get; set; }
    [Required] public Guid TypeIdentificationId { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string Contact { get; set; }
    public TypeUser? TypeUser { get; set; }
    [Required] public Guid TypeUserId { get; set; }
    public bool HasHealthInsurance { get; set; }
}
