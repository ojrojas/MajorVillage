namespace School.Core.Dtos;

public record UpdateCourseResponse : BaseResponse
{
    public UpdateCourseResponse(Guid correlationId) : base(correlationId)
    {
    }

    public Course CourseUpdated { get; set; }
}
