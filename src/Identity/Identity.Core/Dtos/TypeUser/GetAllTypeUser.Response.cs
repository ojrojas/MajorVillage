namespace Identity.Core.Dtos;

public record GetAllTypeUserResponse : BaseResponse
{
	public GetAllTypeUserResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<TypeUser> TypeUsers { get; set; }
}

