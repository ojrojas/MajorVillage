namespace Identity.Core.Dtos;

public record GetAllUserApplicationResponse : BaseResponse
{
	public GetAllUserApplicationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<ApplicationUser>? UserApplications { get; set; }
}