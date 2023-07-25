namespace Identity.Tests;

public class IdentityApiFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSerilog();

        builder.ConfigureServices(services =>
        {
            services.AddTransient(sp =>
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