namespace MajorVillage.Core.Entities;

public class Student: BaseEntity,  IAggregateRoot
{
    public string Identification {get;set;}
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName {get;set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
}