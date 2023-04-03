namespace Core.Dtos;

public record CreateTypeUserResponse : BaseResponse
{
	public CreateTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUserCreated { get; set; }
}

