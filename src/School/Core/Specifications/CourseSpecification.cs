namespace Core.Specifications;

public class CourseSpecification: Specification<Course>
{
	public CourseSpecification(Guid ElectiveYearId)
	{
		Query.Where(course => course.Id.Equals(ElectiveYearId));
	}
}

