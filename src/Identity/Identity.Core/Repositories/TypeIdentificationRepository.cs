namespace Identity.Core.Repositories;

public class TypeIdentificationRepository : GenericRepository<TypeIdentification>
{
    public TypeIdentificationRepository(
        ILogger<GenericRepository<TypeIdentification>> logger,
        IdentityAppDbContext context) : base(logger, context)
    {

    }
}

