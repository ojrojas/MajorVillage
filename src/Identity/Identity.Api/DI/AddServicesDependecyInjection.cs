namespace Identity.Api.DI;

internal static class AddServicesDependecyInjection
{
    public static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddTransient(typeof(GenericRepository<>));

        services.AddTransient(typeof(TypeIdentificationRepository));
        services.AddTransient(typeof(UserApplicationRepository));
        services.AddTransient(typeof(TypeUserRepository));

        services.AddTransient<ITypeIdentificationService, TypeIdentificationService>();
        services.AddTransient<ITypeUserService, TypeUserService>();
        services.AddTransient<IUserApplicationService, UserApplicationService>();

        services.AddTransient<InitializerDbContext>();

        return services;
    }
}