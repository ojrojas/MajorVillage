namespace Identity.Core.Repositories;

public class UserApplicationRepository : GenericRepository<ApplicationUser>
{
    public UserApplicationRepository(
        ILogger<GenericRepository<ApplicationUser>> logger,
        IdentityAppDbContext context) : base(logger, context)
    {

    }
}