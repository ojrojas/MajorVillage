namespace MajorVillage.Core.Interfaces;

public class DeleteCourseResponse: BaseResponse
{
    public DeleteCourseResponse(Guid CorrelationId): base(CorrelationId){}
    public bool CourseDeleteDto { get; set; }
}