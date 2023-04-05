namespace Identity.Core.Dtos;

public record GetTypeIdentificationByIdResponse : BaseResponse
{
	public GetTypeIdentificationByIdResponse(Guid CorrelationId): base(CorrelationId){}
	public TypeIdentification TypeIdentification { get; set; }
}

