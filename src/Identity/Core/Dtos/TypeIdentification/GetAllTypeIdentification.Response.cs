namespace Core.Dtos;

public class GetAllTypeIdentificationResponse: BaseResponse
{
	public GetAllTypeIdentificationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<TypeIdentification> TypeIdentifications { get; set; }
}

