namespace Core.Dtos;

public record CreateUserResponse : BaseResponse
{
	public CreateUserResponse(Guid CorrelationId): base(CorrelationId){	}
	public User UserCreated { get; set; }
}

