namespace Core.Dtos;

public record GetAllAttendantResponse : BaseResponse
{
	public GetAllAttendantResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<Attendant> Attendants { get; set; }
}

