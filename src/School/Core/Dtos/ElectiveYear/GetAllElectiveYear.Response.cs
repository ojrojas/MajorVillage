namespace Core.Dtos;

public record GetAllElectiveYearResponse: BaseResponse
{
	public GetAllElectiveYearResponse(Guid correlationId): base(correlationId)
	{
	}

	public IEnumerable<ElectiveYear> ElectiveYears { get; set; }
}

