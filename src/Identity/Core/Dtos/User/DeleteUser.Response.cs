namespace Core.Dtos;

public class DeleteUserResponse: BaseResponse
{
	public DeleteUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public bool UserDeleted { get; set; }
}

