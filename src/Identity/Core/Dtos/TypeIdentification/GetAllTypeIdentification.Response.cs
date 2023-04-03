namespace Core.Dtos;

public record GetAllTypeIdentificationResponse : BaseResponse
{
	public GetAllTypeIdentificationResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<TypeIdentification> TypeIdentifications { get; set; }
}

