namespace School.Core.Dtos;

public record CreateCourseRequest : BaseRequest
{
    public Course Course { get; set; }
}
