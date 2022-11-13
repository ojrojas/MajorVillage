namespace Core.Dtos;

public class GetTypeIdentificationByIdResponse: BaseResponse
{
	public GetTypeIdentificationByIdResponse(Guid CorrelationId): base(CorrelationId){}
	public TypeIdentification TypeIdentification { get; set; }

}

