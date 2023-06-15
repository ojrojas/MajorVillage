namespace Identity.Core.Repositories;

public class UserApplicationRepository : GenericRepository<UserApplication>
{
    public UserApplicationRepository(
        ILogger<GenericRepository<UserApplication>> logger,
        IdentityAppDbContext context) : base(logger, context)
    {

    }
}