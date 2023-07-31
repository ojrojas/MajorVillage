namespace Identity.Core.Dtos;

public record DeleteTypeIdentificationResponse : BaseResponse
{
	public DeleteTypeIdentificationResponse(Guid CorrelationId): base(CorrelationId){	}
	public bool IsTypeIdentificationDeleted { get; set; }
}

