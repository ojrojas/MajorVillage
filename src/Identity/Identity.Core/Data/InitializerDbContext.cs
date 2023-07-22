namespace Identity.Core.Data;

public class InitializerDbContext
{
    private readonly IdentityAppDbContext _context;
    private readonly IPasswordHasher<UserApplication> _passwordHasher = new PasswordHasher<UserApplication>();

    public InitializerDbContext(IdentityAppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
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

    public virtual async Task RunConfigurationDbContext(IOpenIddictApplicationManager manager, IOpenIddictScopeManager _scopeManager, Dictionary<string, string> clientsUrls)
    {
        try
        {
            var url = new Uri($"{clientsUrls["IdentityApi"]}/swagger/oauth2-redirect.html");
            if (await manager.FindByClientIdAsync("identityswaggerui") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "identityswaggerui",
                    DisplayName = "Identity Swagger UI",
                    ClientSecret = "a961a072-4a69-4b10-bc17-1551d454d44c",
                    ConsentType = ConsentTypes.Implicit,
                    RedirectUris = { new Uri($"{clientsUrls["IdentityApi"]}/swagger/oauth2-redirect.html") },
                    Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.Endpoints.Logout,
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "identity",
                    },
                    PostLogoutRedirectUris = { new Uri($"{clientsUrls["IdentityApi"]}/swagger") },
                    Requirements = { Requirements.Features.ProofKeyForCodeExchange }
                });
            }

            if (await manager.FindByClientIdAsync("schoolswaggerui") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "schoolswaggerui",
                    DisplayName = "School Swagger UI",
                    ClientSecret = "3e0e4c3c-8f86-4cc7-9269-f2db2f1a93c6",

                    RedirectUris = { new Uri($"{clientsUrls["SchoolApi"]}/swagger/oauth2-redirect.html") },
                    Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.ClientCredentials,
                        Permissions.GrantTypes.AuthorizationCode,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Code,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "school",
                    },
                    PostLogoutRedirectUris = { new Uri($"{clientsUrls["SchoolApi"]}/swagger") },
                });
            }

            if (await manager.FindByClientIdAsync("majorweb-client") is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "majorweb-client",
                    DisplayName = "Major Web React",
                    ClientSecret = "db7193c2-d4bd-4b0b-8218-d14c468b140a",

                    RedirectUris = { new Uri("https://oauth.pstmn.io/v1/callback") },
                    Permissions = {
                        Permissions.Endpoints.Token,
                        Permissions.GrantTypes.Password,
                        Permissions.Endpoints.Authorization,
                        Permissions.ResponseTypes.Token,
                        Permissions.Scopes.Email,
                        Permissions.Scopes.Profile,
                        Permissions.Scopes.Roles,
                        Permissions.Prefixes.Scope + "school",
                        Permissions.Prefixes.Scope + "identity",
                        Permissions.Prefixes.Scope + "noteandmaths",
                    },
                    PostLogoutRedirectUris = { new Uri($"{clientsUrls["MajorWeb"]}/login") },
                });
            }

            if (await _scopeManager.FindByNameAsync("SchoolScope") is null)
            {
                await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
                {
                    Name = "SchoolScope",
                    DisplayName = "School Api",
                    Resources = {
                        "resource_school"
                    }
                });
            }

            if (await _scopeManager.FindByNameAsync("NoteAndMathsScope") is null)
            {
                await _scopeManager.CreateAsync(new OpenIddictScopeDescriptor
                {
                    Name = "NoteAndMathsScope",
                    DisplayName = "Note And Maths Api",
                    Resources = {
                        "resource_noteandmaths"
                    }
                });
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }
}