namespace MajorVillage.Core.Dtos;

public class DeleteElectiveYearResponse: BaseResponse
{
    public DeleteElectiveYearResponse(Guid CorrelationId): base(CorrelationId){}
    public bool ElectiveYearDeleted { get; set; }
}