namespace Core.Dtos;

public record GetAllEnrollmentResponse: BaseResponse
{
	public GetAllEnrollmentResponse(Guid correlationId): base(correlationId) { }
	public IEnumerable<Enrollment> Enrollments{ get; set; }
}

public record GetAllEnrollmentByElectiveYearResponse: BaseResponse
{
	public GetAllEnrollmentByElectiveYearResponse(Guid correlationId) : base(correlationId) { }
public IEnumerable<Enrollment> Enrollments { get; set; }
}

