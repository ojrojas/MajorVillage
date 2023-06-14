namespace Identity.Core.Dtos;
public record LoginUserApplicationRequest : BaseRequest 
{
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}

