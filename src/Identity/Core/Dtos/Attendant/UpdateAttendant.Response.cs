namespace Core.Dtos;

public class UpdateAttendantResponse: BaseResponse
{
	public UpdateAttendantResponse(Guid CorrelationId) : base(CorrelationId){}
	public Attendant TypeIdenticicationUpdated{ get; set; }
}

