using Microsoft.AspNetCore.Http;

namespace Identity.Core.Dtos;

public record LoginUserApplicationResponse : BaseResponse
{
	public LoginUserApplicationResponse(Guid CorrelationId): base(CorrelationId){}

	public string Token { get; set; } = string.Empty;
    public IResult ActionResult { get; set; } = null!;
}

