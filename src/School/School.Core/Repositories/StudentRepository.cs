namespace School.Core.Repositories;

public class StudentRepository : GenericRepository<Student>
{
    public StudentRepository(ILogger<GenericRepository<Student>> logger, SchoolDbContext context) : base(logger, context)
    {
    }
}

