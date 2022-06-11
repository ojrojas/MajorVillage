namespace MajorVillage.Core.Dtos;

public class UpdateEnrollmentResponse : BaseResponse
{
    public UpdateEnrollmentResponse(Guid CorrelationId) : base(CorrelationId) { }

    public bool EnrollmentUpdated { get; set; }
}