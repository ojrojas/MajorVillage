namespace Core.Dtos;

public class DeleteUserApplicationResponse: BaseResponse
{
	public DeleteUserApplicationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public UserApplication UserApplicationDeleted { get; set; }
}

