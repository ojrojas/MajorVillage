namespace School.Core.Dtos;

public record UpdateEnrollmentResponse: BaseResponse
{
	public UpdateEnrollmentResponse(Guid correlationId): base(correlationId) { }
	public Enrollment EnrollmentUpdated { get; set; }
}

