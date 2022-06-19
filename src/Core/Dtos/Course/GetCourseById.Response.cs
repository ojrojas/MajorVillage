namespace MajorVillage.Core.Interfaces;

public class GetCourseByIdResponse: BaseResponse
{
    public GetCourseByIdResponse(Guid CorrelationId): base(CorrelationId) {}

    public Course Course { get; set; }
}