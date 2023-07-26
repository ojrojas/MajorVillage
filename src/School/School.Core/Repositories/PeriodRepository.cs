namespace School.Core.Repositories;

public class PeriodRepository : GenericRepository<Period>
{
    public PeriodRepository(ILogger<GenericRepository<Period>> logger, SchoolDbContext context) : base(logger, context)
    {
    }
}

