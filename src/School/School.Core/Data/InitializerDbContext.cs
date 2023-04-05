namespace School.Core.Data;

public class InitializerDbContext
{
	private readonly SchoolDbContext _context;

    public InitializerDbContext(SchoolDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async virtual Task Run()
	{
        await _context.Database.EnsureCreatedAsync();
	}
}

