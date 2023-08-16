namespace Aggregator.Web.Api.DI;

public static class DIOpenIddictApplication
{
	public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
	{
        services.AddOpenIddict()
            .AddValidation(config =>
            {
                config.SetIssuer(configuration["IdentityUrl"]);
                config.AddAudiences("resource_jukebox");

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

