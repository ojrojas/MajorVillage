namespace Identity.Core.Repositories;

public class AttendantRepository : GenericRepository<Attendant>
{
    public AttendantRepository(
        ILogger<GenericRepository<Attendant>> logger,
        IdentityAppDbContext context) : base(logger, context)
    {

    }
}

