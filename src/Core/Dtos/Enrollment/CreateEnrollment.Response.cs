namespace MajorVillage.Core.Dtos;

public class CreateEnrollmentResponse : BaseResponse
{
    public CreateEnrollmentResponse(Guid CorrelationId) : base(CorrelationId) { }
    public Guid Id { get; set; }
}