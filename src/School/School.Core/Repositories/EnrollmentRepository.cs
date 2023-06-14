namespace School.Core.Repositories;

public class EnrollmentRepository: GenericRepository<Enrollment>
{
    public EnrollmentRepository(ILogger<EnrollmentRepository> logger,
                                SchoolDbContext context) : base(logger, context)
    {
    }

}

