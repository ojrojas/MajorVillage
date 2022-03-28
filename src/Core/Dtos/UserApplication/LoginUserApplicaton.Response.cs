namespace MajorVillage.Core.Dtos;

public class LoginUserApplicationResponse : BaseResponse
{
    public LoginUserApplicationResponse(Guid correlationId):base(correlationId){}

    public UserApplication UserApplicationDto { get; set; }
}
