namespace Core.Dtos;

public class DeleteTypeUserResponse: BaseResponse
{
	public DeleteTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUserDeleted { get; set; }
}

