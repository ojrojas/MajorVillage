namespace Identity.Core.Dtos;

public record GetUserByIdResponse: BaseResponse
{
	public GetUserByIdResponse(Guid correlationId): base(correlationId)
	{
	}

	public UserApplication UserApplication { get; set; }
}

