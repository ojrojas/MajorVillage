namespace MajorVillage.Core.Dtos;

public class UpdateEnrollmentRequest: BaseRequest
{
    public Enrollment Enrollment { get; set; }
}