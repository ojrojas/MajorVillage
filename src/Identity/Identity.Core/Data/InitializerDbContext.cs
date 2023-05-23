namespace Identity.Core.Data;

public class InitializerDbContext
{
	private readonly IdentityDbContext _context;
    private readonly IEncryptService _encryptService;

    public InitializerDbContext(IdentityDbContext context, IEncryptService encryptService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _encryptService = encryptService ?? throw new ArgumentNullException(nameof(encryptService));
    }

    public virtual async Task Run()
	{
#if DEBUG
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.EnsureCreatedAsync();
        var userApplication = SeedIdentity.CreateUserApplicationRequest();
        userApplication.Password = await _encryptService.Encrypt(userApplication.Password);
        await _context.UsersApplications.AddAsync(userApplication);
        await _context.SaveChangesAsync();
#endif
	}
}