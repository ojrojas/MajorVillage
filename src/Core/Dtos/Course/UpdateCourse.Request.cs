namespace MajorVillage.Core.Interfaces;

public class UpdateCourseRequest: BaseRequest
{
    public Course Course { get; set; }
}