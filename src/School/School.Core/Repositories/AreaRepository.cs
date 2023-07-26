namespace School.Core.Repositories;

public class AreaRepository : GenericRepository<Area>
{
    public AreaRepository(ILogger<GenericRepository<Area>> logger, SchoolDbContext context) : base(logger, context)
    {
    }
}

