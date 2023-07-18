namespace Identity.Core.Dtos;
public record LoginUserApplicationRequest : BaseRequest 
{
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public IEnumerable<string> Scopes { get; set; } = null!;
}

