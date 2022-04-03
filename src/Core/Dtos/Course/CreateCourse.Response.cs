namespace MajorVillage.Core.Dtos;

public class CreateCourseResponse :BaseResponse
{
    public CreateCourseResponse(Guid CorrelationId): base(CorrelationId) {}

    public Guid Id { get; set; }
}