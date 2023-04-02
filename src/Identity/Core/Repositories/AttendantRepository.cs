namespace Core.Repositories;

public class AttendantRepository : GenericRepository<Attendant>
{
    public AttendantRepository(
        ILogger<GenericRepository<Attendant>> logger,
        IdentityDbContext context) : base(logger, context)
    {

    }
}

