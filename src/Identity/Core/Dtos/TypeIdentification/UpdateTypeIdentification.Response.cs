namespace Core.Dtos;

public class UpdateTypeIdentificationResponse: BaseResponse
{
	public UpdateTypeIdentificationResponse(Guid CorrelationId) : base(CorrelationId){}
	public TypeIdentification TypeIdentificationUpdated{ get; set; }
}

