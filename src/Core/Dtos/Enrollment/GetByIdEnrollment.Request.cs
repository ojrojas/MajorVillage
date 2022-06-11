namespace MajorVillage.Core.Dtos;

public class GetByIdEnrollmentRequest : BaseRequest
{
    public Guid EnrollmentId { get; set; }
}