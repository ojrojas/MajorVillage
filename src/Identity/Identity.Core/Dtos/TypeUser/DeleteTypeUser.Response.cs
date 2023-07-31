namespace Identity.Core.Dtos;

public record DeleteTypeUserResponse : BaseResponse
{
	public DeleteTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public bool IsTypeUserDeleted { get; set; }
}

