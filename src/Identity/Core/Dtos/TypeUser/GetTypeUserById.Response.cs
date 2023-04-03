namespace Core.Dtos;

public record GetTypeUserByIdResponse : BaseResponse
{
	public GetTypeUserByIdResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUser { get; set; }
}

