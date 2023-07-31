namespace Identity.Core.Dtos;

public record DeleteUserApplicationResponse : BaseResponse
{
	public DeleteUserApplicationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public bool IsUserApplicationDeleted { get; set; }
}

