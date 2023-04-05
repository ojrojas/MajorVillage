namespace School.Api.DI;

internal static class AddServicesDependecyInjection
{
    internal static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddTransient(typeof(GenericRepository<>));
        services.AddTransient<InitializerDbContext>();

        return services;
    }
}
