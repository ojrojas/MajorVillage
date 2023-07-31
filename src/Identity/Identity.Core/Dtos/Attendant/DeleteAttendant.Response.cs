namespace Identity.Core.Dtos;

public record DeleteAttendantResponse : BaseResponse
{
	public DeleteAttendantResponse(Guid CorrelationId): base(CorrelationId){	}
	public bool IsAttendantDeleted { get; set; }
}

