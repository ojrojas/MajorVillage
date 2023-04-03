namespace Core.Dtos;

public record UpdateElectiveYearResponse: BaseResponse
{
	public UpdateElectiveYearResponse(Guid correlationId): base(correlationId)
	{
	}

	public ElectiveYear ElectiveYearUpdated { get; set; }
}

