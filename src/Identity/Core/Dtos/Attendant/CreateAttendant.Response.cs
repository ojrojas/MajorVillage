namespace Core.Dtos;

public record CreateAttendantResponse : BaseResponse
{
	public CreateAttendantResponse(Guid CorrelationId): base(CorrelationId){}
	public Attendant AttendantCreated { get; set; }
}

