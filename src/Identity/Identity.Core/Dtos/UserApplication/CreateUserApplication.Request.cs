namespace Identity.Core.Dtos;

public record CreateUserApplicationRequest : BaseRequest
{
    public UserApplication UserApplication { get; set; }
}

