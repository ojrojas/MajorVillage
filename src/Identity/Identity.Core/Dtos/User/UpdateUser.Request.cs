namespace Identity.Core.Dtos;

public record UpdateUserRequest : BaseRequest
{
    public User User { get; set; }
}

