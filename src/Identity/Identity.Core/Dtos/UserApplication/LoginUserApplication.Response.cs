namespace Identity.Core.Dtos;

public record LoginUserApplicationResponse : BaseResponse
{
	public LoginUserApplicationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public string Token { get; set; }
}

