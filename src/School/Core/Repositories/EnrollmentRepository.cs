namespace Core.Repositories;

public class EnrollmentRepository: GenericRepository<Enrollment>
{
	private readonly ILogger<EnrollmentRepository> _logger;
	private readonly SchoolDbContext _context;

    public EnrollmentRepository(ILogger<EnrollmentRepository> logger,
                                DbContext context,
                                ISpecificationEvaluator specificationEvaluator) : base(logger, context, specificationEvaluator)
    {
    }

}

