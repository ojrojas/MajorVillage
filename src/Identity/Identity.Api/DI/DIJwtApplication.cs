using OpenIddict.Validation.AspNetCore;

namespace Identity.Api.DI;

internal static class DIJwtApplication
{
    /// <summary>
    /// Extension Jwt configuration
    /// </summary>
    /// <param name="services">Services application</param>
    /// <param name="configuration">configuration environments</param>
    /// <returns>Service configuration</returns>
    internal static IServiceCollection AddDIJwtApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:SecretPhrase"]);
        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme).AddCookie();
        return services;
    }
}
