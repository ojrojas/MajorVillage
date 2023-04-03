namespace Core.Dtos;

public record UpdateEnrollmentRequest: BaseRequest
{
    public Enrollment Enrollment { get; set; }
}

