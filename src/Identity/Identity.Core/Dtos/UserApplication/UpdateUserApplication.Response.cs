namespace Identity.Core.Dtos;

public record UpdateUserApplicationResponse : BaseResponse
{
	public UpdateUserApplicationResponse(Guid correlationId): base(correlationId)
	{
	}

	public ApplicationUser? UserApplication { get; set; }
}