namespace Core.Dtos;

public record CreateElectiveYearRequest: BaseRequest
{
	public ElectiveYear ElectiveYear { get; set; }
}

