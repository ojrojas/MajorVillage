namespace Core.Dtos;

public record DeleteAttendantResponse : BaseResponse
{
	public DeleteAttendantResponse(Guid CorrelationId): base(CorrelationId){	}
	public Attendant AttendantDeleted { get; set; }
}

