namespace Identity.Api.DI;

internal static class DIIdentityServerApplication
{
    public static IServiceCollection AddIdentityServerApplication(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, TypeUser>()
            .AddEntityFrameworkStores<IdentityAppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}