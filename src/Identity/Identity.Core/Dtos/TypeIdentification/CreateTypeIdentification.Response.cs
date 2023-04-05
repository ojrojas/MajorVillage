namespace Identity.Core.Dtos;

public record CreateTypeIdentificationResponse : BaseResponse
{
	public CreateTypeIdentificationResponse(Guid CorrelationId): base(CorrelationId){}
	public TypeIdentification TypeIdentificationCreated { get; set; }
}

