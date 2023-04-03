namespace Core.Dtos;

public record DeleteTypeIdentificationResponse : BaseResponse
{
	public DeleteTypeIdentificationResponse(Guid CorrelationId): base(CorrelationId){	}
	public TypeIdentification TypeIdentificationDeleted { get; set; }
}

