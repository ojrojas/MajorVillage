namespace School.Core.Specifications;

public class EnrollmentSpecification : Specification<Enrollment>
{
	public EnrollmentSpecification(Guid electiveYearId)
	{
		Query.Where(enrollment => enrollment.Id.Equals(electiveYearId));
	}
}

