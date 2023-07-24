using OpenIddict.Client;

namespace Identity.Tests;

public class IdentityApiFactory : WebApplicationFactory<Program>
{
    private readonly string _environment;

    public IdentityApiFactory(string environment)
    {
        _environment = environment ?? throw new ArgumentNullException(nameof(environment));
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_environment);
        builder.UseSerilog();

        builder.ConfigureServices(services =>
        {
            services.AddScoped(sp =>
            {
                return new DbContextOptionsBuilder<IdentityAppDbContext>()
                .UseInMemoryDatabase("Tests")
                .UseApplicationServiceProvider(sp)
                .UseOpenIddict()
                .Options;
            });
        });

        return base.CreateHost(builder);
    }
}