namespace MajorVillage.Core.Dtos;

public class CreateUserApplicationRequest :BaseRequest
{
  public UserApplication userApplication { get; set; }
}