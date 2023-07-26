namespace School.Core.Repositories;

public class SubjectRepository : GenericRepository<Subject>
{
    public SubjectRepository(ILogger<GenericRepository<Subject>> logger, SchoolDbContext context) : base(logger, context)
    {
    }
}

