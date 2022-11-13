namespace Core.Dtos;

public class GetUserByIdResponse: BaseResponse
{
	public GetUserByIdResponse(Guid CorrelationId): base(CorrelationId){}
	public User User { get; set; }
}

