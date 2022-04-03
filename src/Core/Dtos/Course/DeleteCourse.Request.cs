namespace MajorVillage.Core.Interfaces;

public class DeleteCourseRequest: BaseRequest
{
    public Course CourseDto { get; set; }
}