namespace Identity.Core.Dtos;

public record DeleteTypeUserRequest : BaseRequest
{
    public Guid Id { get; set; }
}

