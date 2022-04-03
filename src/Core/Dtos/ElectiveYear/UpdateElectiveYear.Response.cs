namespace MajorVillage.Core.Dtos;

public class UpdateElectiveYearResponse: BaseResponse
{
    public UpdateElectiveYearResponse(Guid CorrelationId): base(CorrelationId) {}
    public bool ElectiveYearUpdated { get; set; }
}