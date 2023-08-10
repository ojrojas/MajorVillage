namespace School.Api.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenIddict()
            .AddValidation(config =>
            {
                config.SetIssuer(configuration["IdentityUrl"]);
                config.AddAudiences("resource_school");

                //// Spocify3d9c278b-82d1-4b88-944c-82193bea0595
                config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String(configuration["EncryptedKey"])));

                // Register the System.Net.Http integration.
                config.UseSystemNetHttp();

                // Register the ASP.NET Core host.
                config.UseAspNetCore();
            });

        return services;
    }
}
