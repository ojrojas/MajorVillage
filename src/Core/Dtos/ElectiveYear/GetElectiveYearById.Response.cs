namespace MajorVillage.Core.Dtos;

public class GetElectiveYearByIdResponse : BaseResponse
{
    public GetElectiveYearByIdResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ElectiveYear ElectiveYear { get; set; }
}