namespace Identity.Core.Data;

public class InitializerDbContext
{
	private readonly IdentityAppDbContext _context;
    private IPasswordHasher<UserApplication> _passwordHasher = new PasswordHasher<UserApplication>();

    public InitializerDbContext(IdentityAppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public virtual async Task Run()
	{
#if DEBUG
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.EnsureCreatedAsync();
        var userApplication = SeedIdentity.CreateUserApplicationRequest();
        ArgumentNullException.ThrowIfNull(userApplication.PasswordHash);
        userApplication.PasswordHash = _passwordHasher.HashPassword(userApplication, userApplication.PasswordHash);
        await _context.Users.AddAsync(userApplication);
        await _context.SaveChangesAsync();
#endif
	}
}