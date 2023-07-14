namespace Identity.Api.DI;

public static class DIIdentityServerApplication
{
    public static IServiceCollection AddIdentityServerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<UserApplication, IdentityRole>()
            .AddEntityFrameworkStores<IdentityAppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}

