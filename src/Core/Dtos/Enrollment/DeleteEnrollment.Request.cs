namespace MajorVillage.Core.Dtos;

public class DeleteEnrollmentRequest: BaseRequest
{
    public Enrollment Enrollment { get; set; }
}