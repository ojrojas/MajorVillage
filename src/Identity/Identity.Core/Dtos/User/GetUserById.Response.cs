namespace Identity.Core.Dtos;

public record GetUserByIdResponse : BaseResponse
{
	public GetUserByIdResponse(Guid CorrelationId): base(CorrelationId){}
	public User User { get; set; }
}

