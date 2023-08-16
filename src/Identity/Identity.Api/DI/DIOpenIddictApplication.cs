namespace Identity.Api.DI;

internal static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenIddict(cfg =>
        {
            cfg.AddCore(conf =>
                conf.UseEntityFrameworkCore()
                .UseDbContext<IdentityAppDbContext>());

            cfg.AddServer(conf =>
            {
                conf.AllowClientCredentialsFlow();
                conf.AllowPasswordFlow();
                conf.AllowAuthorizationCodeFlow();
                conf.RequireProofKeyForCodeExchange();

                conf.SetTokenEndpointUris("connect/token");
                conf.SetAuthorizationEndpointUris("connect/authorize");
                conf.SetLogoutEndpointUris("/connect/signout");
                conf.SetIntrospectionEndpointUris("connect/introspect");

                conf.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String(configuration["EncryptedKey"])));

                conf.AddSigningCertificate(Certificates.Certificate.GetCert());

                conf.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles, "school", "identity", "noteandmaths");

                conf.UseAspNetCore()
                .DisableTransportSecurityRequirement()
                .EnableAuthorizationEndpointPassthrough()
                .EnableLogoutEndpointPassthrough()
                .EnableTokenEndpointPassthrough();
            });

            cfg.AddValidation(conf =>
            {
                conf.UseLocalServer();
                conf.UseAspNetCore();
            });
        });

        return services;
    }
}

