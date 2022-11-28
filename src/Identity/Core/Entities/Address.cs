namespace Core.Entities
{
    public class Address : BaseEntity, IAggregateRoot
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public SelectedEnum PrincipalAddress { get; set; }
    }
}
