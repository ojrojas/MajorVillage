namespace MajorVillage.Core.Dtos;

public class DeleteEnrollmentResponse : BaseResponse
{
    public DeleteEnrollmentResponse(Guid CorrelationId): base(CorrelationId){}

    public bool DeleteEnrollmentDeleted { get; set; }
}