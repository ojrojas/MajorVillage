namespace Core.Dtos;

public record DeleteElectiveYearResponse: BaseResponse
{
	public DeleteElectiveYearResponse(Guid correlationId): base(correlationId)
	{
	}

	public ElectiveYear ElectiveYearDeleted { get; set; }
}

