namespace Identity.Core.Dtos;

public record UpdateAttendantResponse : BaseResponse
{
	public UpdateAttendantResponse(Guid CorrelationId) : base(CorrelationId){}
	public Attendant TypeIdenticicationUpdated{ get; set; }
}

