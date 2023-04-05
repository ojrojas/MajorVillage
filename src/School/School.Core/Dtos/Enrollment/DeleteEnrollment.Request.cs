namespace School.Core.Dtos;

public record DeleteEnrollmentRequest: BaseRequest
{
	public Guid Id { get; set; }
}

