namespace Identity.Core.Dtos;

public record CreateUserRequest : BaseRequest
{
    public User User { get; set; }
}

