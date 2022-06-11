namespace MajorVillage.Core.Dtos;

public class CreateEnrollmentRequest : BaseRequest
{
    public Enrollment Enrollment { get; set; }
}