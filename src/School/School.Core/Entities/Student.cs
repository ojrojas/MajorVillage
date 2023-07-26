namespace School.Core.Entities;

public class Student: BaseEntity, IAggregateRoot
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? LastName { get; set; }
}

