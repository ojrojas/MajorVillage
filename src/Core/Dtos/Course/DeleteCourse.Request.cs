namespace MajorVillage.Core.Interfaces;

public class DeleteCourseRequest: BaseRequest
{
    public Course Course { get; set; }
}