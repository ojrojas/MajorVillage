namespace Identity.Core.Dtos;

public record DeleteUserRequest : BaseRequest
{
    public Guid Id { get; set; }
}

