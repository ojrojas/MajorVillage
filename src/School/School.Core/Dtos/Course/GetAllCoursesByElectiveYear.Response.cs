namespace School.Core.Dtos;

public record GetAllCoursesByElectiveYearResponse : BaseResponse
{
	public GetAllCoursesByElectiveYearResponse(Guid correlationId): base(correlationId) {}
	public IEnumerable<Course> Courses{ get; set; }
}

