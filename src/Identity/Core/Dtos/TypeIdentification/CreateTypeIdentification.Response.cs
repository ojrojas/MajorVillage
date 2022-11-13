namespace Core.Dtos;

public class CreateTypeIdentificationResponse: BaseResponse
{
	public CreateTypeIdentificationResponse(Guid CorrelationId): base(CorrelationId){}
	public TypeIdentification TypeIdentificationCreated { get; set; }
}

