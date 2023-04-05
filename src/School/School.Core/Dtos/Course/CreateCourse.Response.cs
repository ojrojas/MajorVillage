namespace School.Core.Dtos;

public record CreateCourseResponse : BaseResponse
{
    public CreateCourseResponse(Guid correlationId) : base(correlationId)
    {
    }

    public Course CourseCreated { get; set; }
}
