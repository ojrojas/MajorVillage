namespace Identity.Core.Entities;

public  class TypeUser: BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
}
