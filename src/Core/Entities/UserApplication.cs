namespace MajorVillage.Core.Entities;


public class UserApplication: BaseEntity, IAggregateRoot
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public Guid UserId { get; set; }
}