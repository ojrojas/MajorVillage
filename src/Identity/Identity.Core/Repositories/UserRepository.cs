namespace Identity.Core.Repositories;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(
        ILogger<GenericRepository<User>> logger,
        IdentityDbContext context) : base(logger, context)
    {

    }
}