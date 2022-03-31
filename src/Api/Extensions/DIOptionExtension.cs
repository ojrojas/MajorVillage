
namespace MajorVillage.Api.Extensions;

internal static class DIOptionExtension {
    public static IServiceCollection AddDIOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EncryptOption>(configuration.GetSection("EncryptOptions"));
        return services;
    }
}