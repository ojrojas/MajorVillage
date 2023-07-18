namespace Identity.Api.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services)
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
                //conf.Configure(c => c.CodeChallengeMethods.Add(CodeChallengeMethods.Plain));

                conf.SetTokenEndpointUris("connect/token");
                conf.SetAuthorizationEndpointUris("connect/authorize");
                conf.SetLogoutEndpointUris("/connect/signout");

                conf.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("QXBwbGljYXRpb25NYWpvclNvbHV0aW9uc0lkZW50MTI=")));

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

