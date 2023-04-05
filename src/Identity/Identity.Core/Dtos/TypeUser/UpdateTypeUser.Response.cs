namespace Identity.Core.Dtos;

public record UpdateTypeUserResponse : BaseResponse
{
	public UpdateTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUserUpdated { get; set; }
}

