namespace Core.Dtos;

public record GetAllUserResponse : BaseResponse
{
	public GetAllUserResponse(Guid CorrelationId):base(CorrelationId){	}
	public IEnumerable<User> Users{ get; set; }
}

