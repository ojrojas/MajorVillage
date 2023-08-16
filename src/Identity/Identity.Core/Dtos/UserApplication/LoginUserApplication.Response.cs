using Microsoft.AspNetCore.Http;

namespace Identity.Core.Dtos;

public record LoginUserApplicationResponse : BaseResponse
{
	public LoginUserApplicationResponse(Guid CorrelationId): base(CorrelationId){}

	public int Status { get; set; } = 400;
    public IResult ActionResult { get; set; } = null!;
}

