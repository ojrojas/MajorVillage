namespace MajorVillage.Core.Dtos;

public class CreateElectiveYearResponse : BaseResponse
{
    public CreateElectiveYearResponse(Guid correlationId) : base(correlationId) { }

    public Guid Id { get; set; }
}