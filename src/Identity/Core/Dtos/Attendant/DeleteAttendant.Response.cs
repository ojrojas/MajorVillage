namespace Core.Dtos;

public class DeleteAttendantResponse: BaseResponse
{
	public DeleteAttendantResponse(Guid CorrelationId): base(CorrelationId){	}
	public Attendant AttendantDeleted { get; set; }
}

