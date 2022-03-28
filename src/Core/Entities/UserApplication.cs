namespace MajorVillage.Core.Entities;


public class UserApplication: BaseEntity 
{
    public string UserName { get; set; }
    public string Password { get; set; }
}