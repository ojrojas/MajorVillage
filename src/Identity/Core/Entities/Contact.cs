namespace Core.Entities
{
    public  class Contact: BaseEntity, IAggregateRoot
    {
        public string NumberContact1 { get; set; }
        public string NumberContact2 { get; set;}
        public SelectedEnum PrincipalNumber { get; set; }
    }
}
