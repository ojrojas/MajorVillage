namespace School.Core.Repositories;

public class CourseRepository: GenericRepository<Course>
{
	public CourseRepository(ILogger<CourseRepository> logger,
                            SchoolDbContext context) : base(logger, context)
    {
    }
}

