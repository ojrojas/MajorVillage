namespace MajorVillage.Core.Dtos;

public class CreateUserApplicationRequest :BaseRequest
{
  public UserApplication userApplicationDto { get; set; }
}