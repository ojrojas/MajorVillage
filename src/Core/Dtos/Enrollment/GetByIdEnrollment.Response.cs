namespace MajorVillage.Core.Dtos;

public class GetByIdEnrollmentResponse : BaseResponse
{
    public GetByIdEnrollmentResponse(Guid CorrelationId): base(CorrelationId){}
    public Enrollment Enrollment { get; set; }
}