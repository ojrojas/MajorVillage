namespace Identity.Core.Repositories;

public class TypeUserRepository : GenericRepository<TypeUser>
{
    public TypeUserRepository(
        ILogger<GenericRepository<TypeUser>> logger,
        IdentityDbContext context) : base(logger, context)
    {

    }
}

