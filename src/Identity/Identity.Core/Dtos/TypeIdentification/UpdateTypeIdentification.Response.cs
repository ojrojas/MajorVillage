namespace Identity.Core.Dtos;

public record UpdateTypeIdentificationResponse : BaseResponse
{
	public UpdateTypeIdentificationResponse(Guid CorrelationId) : base(CorrelationId){}
	public TypeIdentification TypeIdentificationUpdated{ get; set; }
}

