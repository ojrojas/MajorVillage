namespace Core.Dtos;

public class GetAllTypeUserResponse : BaseResponse
{
	public GetAllTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<TypeUser> TypeUsers { get; set; }
}

