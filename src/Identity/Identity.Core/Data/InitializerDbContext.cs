using AutoMapper;

namespace Identity.Core.Data;

public class InitializerDbContext
{
    private readonly IdentityAppDbContext _context;
    private readonly ConfigurationDbContext _context2;
    private IPasswordHasher<UserApplication> _passwordHasher = new PasswordHasher<UserApplication>();

    public InitializerDbContext(IdentityAppDbContext context, ConfigurationDbContext context2)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _context2 = context2 ?? throw new ArgumentNullException(nameof(context2));
    }

    public virtual async Task Run()
    {
#if DEBUG
        try
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
            var usersApplications = _context.Users;
            if (!usersApplications.Any())
            {
                var userApplication = SeedIdentity.CreateUserApplicationRequest();
                ArgumentNullException.ThrowIfNull(userApplication.PasswordHash);
                userApplication.PasswordHash = _passwordHasher.HashPassword(userApplication, userApplication.PasswordHash);
                await _context.Users.AddAsync(userApplication);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
#endif
    }

    public virtual async Task RunConfigurationDbContext(IConfiguration configuration)
    {
        try
        {
            var clientsUrls = new Dictionary<string, string>
            {
                ["SchoolApiClient"] = configuration["SchoolApiClient"]
            };

            if (!_context2.Clients.Any())
            {
                foreach (var client in IdentityConfig.GetClients(clientsUrls))
                {
                    _context2.Clients.Add(client.ToEntity());
                }
                await _context2.SaveChangesAsync();
            }

            if (!_context2.IdentityResources.Any())
            {
                foreach (var resource in IdentityConfig.GetResources())
                {
                    await _context2.IdentityResources.AddAsync(resource.ToEntity());
                }

                await _context2.SaveChangesAsync();
            }

            if (!_context2.ApiResources.Any())
            {
                foreach (var resource in IdentityConfig.GetApis())
                {
                    await _context2.AddAsync(resource.ToEntity());
                }

                await _context2.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}