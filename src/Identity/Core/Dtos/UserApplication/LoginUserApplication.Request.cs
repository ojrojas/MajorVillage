namespace Core.Dtos;
public class LoginUserApplicationRequest : BaseRequest 
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

