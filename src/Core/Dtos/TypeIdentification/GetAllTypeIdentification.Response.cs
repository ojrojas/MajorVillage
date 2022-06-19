namespace MajorVillage.Core.Dtos;

public class GetAllTypeIdentificationResponse: BaseResponse
{
    public GetAllTypeIdentificationResponse(Guid correlationId) : base(correlationId)
    {
    }

    public IEnumerable<TypeIdentification> TypeIdentifications { get; set; }
}