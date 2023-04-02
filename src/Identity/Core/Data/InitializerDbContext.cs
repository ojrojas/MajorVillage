namespace Core.Data;

public class InitializerDbContext
{
	private readonly IdentityDbContext _context;

    public InitializerDbContext(IdentityDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public virtual async Task Run()
	{
        await _context.Database.EnsureCreatedAsync();
	}
}

