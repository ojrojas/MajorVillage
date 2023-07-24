namespace Identity.Api.DI;

public static class DIIdentityServerApplication
{
    public static IServiceCollection AddIdentityServerApplication(this IServiceCollection services)
    {
        services.AddIdentity<UserApplication, IdentityRole>()
            .AddEntityFrameworkStores<IdentityAppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}

