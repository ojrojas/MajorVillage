namespace Core.Dtos;

public record GetAttendantByIdResponse : BaseResponse
{
	public GetAttendantByIdResponse(Guid CorrelationId): base(CorrelationId){}
	public Attendant Attendant { get; set; }

}

