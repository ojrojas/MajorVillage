namespace Core.Entities
{
    public class TypeIdentification: BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
