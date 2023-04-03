namespace Core.Dtos;

public record DeleteAttendantRequest : BaseRequest
{
	public Guid Id { get; set; }
}

