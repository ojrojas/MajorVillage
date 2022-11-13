namespace Core.Dtos;

public class UpdateUserResponse: BaseResponse
{
	public UpdateUserResponse(Guid CorrelationId): base(CorrelationId)	{}
	public User UserUpdated { get; set; }
}