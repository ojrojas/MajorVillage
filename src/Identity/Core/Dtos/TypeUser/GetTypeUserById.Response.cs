namespace Core.Dtos;

public class GetTypeUserByIdResponse: BaseResponse
{
	public GetTypeUserByIdResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public TypeUser TypeUser { get; set; }
}

