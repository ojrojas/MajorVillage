namespace Identity.Api.DI;

public static class DIIdentityServerApplication
{
    public static IServiceCollection AddIdentityServerApplication(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, TypeUser>()
            .AddEntityFrameworkStores<IdentityAppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}

