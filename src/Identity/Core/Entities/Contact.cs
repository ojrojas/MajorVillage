namespace Core.Entities
{
    public  class Contact: BaseEntity, IAggregateRoot
    {
        public string NumberContact { get; set; }
        public string NumberContact2 { get; set;}
        public int PrincipalNumber { get; set; }
    }
}
