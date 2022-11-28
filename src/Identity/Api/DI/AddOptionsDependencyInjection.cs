using Infraestructure.Configuration;

namespace Api.DI
{
    internal static class AddOptionsDependencyInjections
    {
        public static IServiceCollection AddOptionsExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OptionEncrypt>(configuration.GetSection("OptionEncrypt"));
            services.Configure<OptionToken>(configuration.GetSection("Jwt"));
            return services;
        }
    }
}
