namespace MajorVillage.Core.Dtos;

public class GetByIdEnrollmentRequest : BaseRequest
{
    public Guid Id { get; set; }
}