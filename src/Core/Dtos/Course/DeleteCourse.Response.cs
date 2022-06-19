namespace MajorVillage.Core.Interfaces;

public class DeleteCourseResponse: BaseResponse
{
    public DeleteCourseResponse(Guid CorrelationId): base(CorrelationId){}
    public bool CourseDelete { get; set; }
}