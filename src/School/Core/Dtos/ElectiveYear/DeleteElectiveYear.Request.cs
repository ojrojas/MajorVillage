namespace Core.Dtos;

public record DeleteElectiveYearRequest: BaseRequest
{
	public Guid Id { get; set; }
}

