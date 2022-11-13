namespace Core.Dtos;

public class UpdateTypeUserResponse: BaseResponse
{
	public UpdateTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUserUpdated { get; set; }
}

