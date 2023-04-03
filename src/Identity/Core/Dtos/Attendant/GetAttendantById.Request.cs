namespace Core.Dtos;

public record GetAttendantByIdRequest : BaseRequest
{
	public Guid Id { get; set; }
}

