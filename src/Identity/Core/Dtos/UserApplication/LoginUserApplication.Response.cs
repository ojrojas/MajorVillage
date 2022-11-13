namespace Core.Dtos;

public class LoginUserApplicationResponse: BaseResponse
{
	public LoginUserApplicationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public string Token { get; set; }
}

