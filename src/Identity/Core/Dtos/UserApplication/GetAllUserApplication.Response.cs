namespace Core.Dtos;

public class GetAllUserApplicationResponse: BaseResponse
{
	public GetAllUserApplicationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<UserApplication> UserApplications { get; set; }
}

