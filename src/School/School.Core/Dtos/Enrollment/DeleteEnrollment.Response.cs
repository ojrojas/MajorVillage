namespace School.Core.Dtos;

public record DeleteEnrollmentResponse: BaseResponse
{
	public DeleteEnrollmentResponse(Guid correlationId): base(correlationId)
	{
	}

	public Enrollment EnrollmentDeleted { get; set; }
}

