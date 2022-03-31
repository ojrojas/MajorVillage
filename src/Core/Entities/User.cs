namespace MajorVillage.Core.Entities;


public class User : BaseEntity, IAggregateRoot
{
    public string FirstName { get; set; }
    public string Middlename { get; set; }
    public string LastName { get; set; }
    public string SurName { get; set; }
    public string Identification { get; set; }
    public Guid TypeIdentification { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid TypeUser { get; set; }
}