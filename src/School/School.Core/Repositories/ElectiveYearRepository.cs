namespace School.Core.Repositories;

public class ElectiveYearRepository: GenericRepository<ElectiveYear>
{
    public ElectiveYearRepository(ILogger<ElectiveYearRepository> logger,
                                  SchoolDbContext context) : base(logger, context)
    {
    }
}

