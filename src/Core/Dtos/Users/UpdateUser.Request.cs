namespace MajorVillage.Core.Dtos;

public class UpdateUserRequest : BaseResponse
{
   public User UserDto { get; set; }
}