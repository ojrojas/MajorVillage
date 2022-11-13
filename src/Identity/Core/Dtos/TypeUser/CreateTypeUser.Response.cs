namespace Core.Dtos;

public class CreateTypeUserResponse: BaseResponse
{
	public CreateTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUserCreated { get; set; }
}

