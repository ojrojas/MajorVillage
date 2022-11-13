namespace Core.Dtos;

public class CreateUserResponse: BaseResponse
{
	public CreateUserResponse(Guid CorrelationId): base(CorrelationId){	}
	public User UserCreated { get; set; }
}

