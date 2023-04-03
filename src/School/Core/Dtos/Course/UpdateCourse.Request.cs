namespace Core.Dtos;

public record UpdateCourseRequest : BaseRequest
{
    public Course Course { get; set; }
}
