namespace Identity.Core.Dtos;

public record UpdateUserApplicationRequest: BaseRequest
{
    public UserApplication? UserApplication { get; set; }
}

