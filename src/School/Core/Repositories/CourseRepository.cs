namespace Core.Repositories;

public class CourseRepository: GenericRepository<Course>
{
	private readonly SchoolDbContext _context;
	private readonly ILogger<CourseRepository> _logger;

    public CourseRepository(ILogger<CourseRepository> logger,
                            DbContext context,
                            ISpecificationEvaluator specificationEvaluator) : base(logger, context, specificationEvaluator)
    {
    }
}

