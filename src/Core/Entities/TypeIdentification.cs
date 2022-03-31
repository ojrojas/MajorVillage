namespace MajorVillage.Core.Entities;

public class TypeIdentification: BaseEntity,IAggregateRoot
{
    public string TypeName { get; set; }
}