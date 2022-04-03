namespace MajorVillage.Core.Dtos;

public class CreateCourseRequest: BaseRequest 
{
    public Course CourseDto { get; set; }
}