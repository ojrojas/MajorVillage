namespace Core.Entities
{
    public class Course: BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
