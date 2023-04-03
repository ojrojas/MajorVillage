namespace Core.Dtos;

public record CreateEnrollmentResponse: BaseResponse
{
	public CreateEnrollmentResponse(Guid correlationId): base(correlationId) { }
	public Enrollment EnrollmentCreated { get; set; }
}

