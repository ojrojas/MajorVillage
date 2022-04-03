namespace MajorVillage.Core.Interfaces;

public class GetAllCoursesResponse: BaseResponse
{
    public GetAllCoursesResponse(Guid CorrelationId): base(CorrelationId){}
    public IEnumerable<Course> CoursesDto { get; set; }
}