namespace Identity.Core.Repositories;

public class TypeIdentificationRepository : GenericRepository<TypeIdentification>
{
    public TypeIdentificationRepository(
        ILogger<GenericRepository<TypeIdentification>> logger,
        IdentityDbContext context) : base(logger, context)
    {

    }
}

