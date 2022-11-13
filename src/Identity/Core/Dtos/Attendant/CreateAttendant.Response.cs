namespace Core.Dtos;

public class CreateAttendantResponse: BaseResponse
{
	public CreateAttendantResponse(Guid CorrelationId): base(CorrelationId){}
	public Attendant AttendantCreated { get; set; }
}

