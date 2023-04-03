namespace Core.Dtos;

public record DeleteTypeIdentificationRequest : BaseRequest
{
	public Guid Id { get; set; }
}

