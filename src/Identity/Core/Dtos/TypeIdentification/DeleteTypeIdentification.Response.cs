namespace Core.Dtos;

public class DeleteTypeIdentificationResponse: BaseResponse
{
	public DeleteTypeIdentificationResponse(Guid CorrelationId): base(CorrelationId){	}
	public TypeIdentification TypeIdentificationDeleted { get; set; }
}

