namespace Core.Dtos;

public class GetAllAttendantResponse: BaseResponse
{
	public GetAllAttendantResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<Attendant> Attendants { get; set; }
}

