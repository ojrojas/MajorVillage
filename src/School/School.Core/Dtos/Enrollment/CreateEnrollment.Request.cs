namespace School.Core.Dtos;

public record CreateEnrollmentRequest: BaseRequest
{
	public Enrollment Enrollment { get; set; }
}

