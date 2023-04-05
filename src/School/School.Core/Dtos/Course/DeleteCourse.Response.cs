namespace School.Core.Dtos;

public record DeleteCourseResponse : BaseResponse
{
    public DeleteCourseResponse(Guid correlationId) : base(correlationId)
    {
    }

    public Course CourseDeleted { get; set; }
}