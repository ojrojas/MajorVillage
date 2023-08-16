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

                config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String(configuration["EncryptedKey"])));

                config.UseIntrospection()
                .SetClientId(configuration["aggregatorclient"])
                .SetClientSecret(configuration["752b827a-08a5-483f-abcd-d9e9fabdf657"]);

                // Register the System.Net.Http integration.
                config.UseSystemNetHttp();

                // Register the ASP.NET Core host.
                config.UseAspNetCore();
            });

        return services;
    }
}