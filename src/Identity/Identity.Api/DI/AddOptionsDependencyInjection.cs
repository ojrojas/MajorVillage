namespace Identity.Api.DI;

internal static class AddOptionsDependencyInjections
{
    public static IServiceCollection AddOptionsExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
