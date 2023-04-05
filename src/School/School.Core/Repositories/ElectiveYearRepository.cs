namespace School.Core.Repositories;

public class ElectiveYearRepository: GenericRepository<ElectiveYear>
{
	private readonly ILogger<ElectiveYearRepository> _logger;
	private readonly SchoolDbContext _context;

    public ElectiveYearRepository(ILogger<ElectiveYearRepository> logger,
                                  DbContext context,
                                  ISpecificationEvaluator specificationEvaluator) : base(logger, context, specificationEvaluator)
    {
    }
}

