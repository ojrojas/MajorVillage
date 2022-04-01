namespace MajorVillage.Core.Dtos;

public class GetElectiveYearByIdRequest : BaseRequest
{
    public Guid Id { get; set; }
}