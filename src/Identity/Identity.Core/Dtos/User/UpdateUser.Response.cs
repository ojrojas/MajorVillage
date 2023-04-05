namespace Identity.Core.Dtos;

public record UpdateUserResponse : BaseResponse
{
	public UpdateUserResponse(Guid CorrelationId): base(CorrelationId)	{}
	public User UserUpdated { get; set; }
}