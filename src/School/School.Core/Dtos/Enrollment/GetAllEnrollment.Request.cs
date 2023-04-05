namespace School.Core.Dtos;

public record GetAllEnrollmentRequest: BaseRequest
{

}

public record GetAllEnrollmentByElectiveYearRequest: BaseRequest
{
    public Guid ElectiveYearId { get; set; }
}

