namespace Identity.Core.Repositories;

public class TypeUserRepository : GenericRepository<TypeUser>
{
    public TypeUserRepository(
        ILogger<GenericRepository<TypeUser>> logger,
        IdentityAppDbContext context) : base(logger, context)
    {

    }
}

