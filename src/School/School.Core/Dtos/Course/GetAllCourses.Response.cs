namespace School.Core.Dtos;

public record GetAllCoursesResponse : BaseResponse
{
    public GetAllCoursesResponse(Guid correlationId) : base(correlationId)
    {
    }

    public IEnumerable<Course> Courses { get; set; }
}
