namespace Core.Dtos;

public class GetAllUserResponse: BaseResponse
{
	public GetAllUserResponse(Guid CorrelationId):base(CorrelationId){	}
	public IEnumerable<User> Users{ get; set; }
}

