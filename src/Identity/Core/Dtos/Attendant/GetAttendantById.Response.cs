namespace Core.Dtos;

public class GetAttendantByIdResponse: BaseResponse
{
	public GetAttendantByIdResponse(Guid CorrelationId): base(CorrelationId){}
	public Attendant Attendant { get; set; }

}

