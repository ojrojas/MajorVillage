namespace Identity.Api.DI;

internal static class DIJwtApplication
{
    /// <summary>
    /// Extension Jwt configuration
    /// </summary>
    /// <param name="services">Services application</param>
    /// <returns>Service configuration</returns>
    internal static IServiceCollection AddDIJwtApplication(this IServiceCollection services)
    {
        services.AddAuthorization()
            .AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)
            .AddCookie();
        return services;
    }
}
