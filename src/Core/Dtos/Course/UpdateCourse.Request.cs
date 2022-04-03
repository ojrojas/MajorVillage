namespace MajorVillage.Core.Interfaces;

public class UpdateCourseRequest: BaseRequest
{
    public Course CourseDto { get; set; }
}