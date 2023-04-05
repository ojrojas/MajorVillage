namespace Identity.Core.Dtos;

public record DeleteUserApplicationRequest : BaseRequest
{
    public Guid Id { get; set; }
}

