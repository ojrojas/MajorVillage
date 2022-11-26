namespace Core.Dtos;
public class LoginUserApplicationRequest : BaseRequest 
{
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; }
    public string Password { get; set; }
}

