namespace MajorVillage.Core.Interfaces;

public class UpdateCourseResponse: BaseResponse
{
    public UpdateCourseResponse(Guid CorrelationId): base(CorrelationId) {}
    public bool CourseUpdated { get; set; }
}