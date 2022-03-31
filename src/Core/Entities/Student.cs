namespace MajorVillage.Core.Entities;

public class Student: BaseEntity,  IAggregateRoot
{
    public string Identification {get;set;}
    public string FirstName { get; set; }
    public string MiddleName {get;set;}
    public string LastName { get; set; }
    
}