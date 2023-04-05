namespace Identity.Core.Dtos;

public record DeleteUserApplicationResponse : BaseResponse
{
	public DeleteUserApplicationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public UserApplication UserApplicationDeleted { get; set; }
}

