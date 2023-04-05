namespace School.Core.Dtos;

public record CreateElectiveYearResponse: BaseResponse
{
	public CreateElectiveYearResponse(Guid correlationId): base(correlationId)
	{
	}

	public ElectiveYear ElectiveYearCreated { get; set; }
}

