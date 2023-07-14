namespace Identity.Api.DI;

internal static class DIOptionsApplication
{
    public static IServiceCollection AddOptionsExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
