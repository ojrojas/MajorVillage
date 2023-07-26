namespace School.Api.DI;

internal static class DISwaggerApplication
{
    internal static IServiceCollection AddDISwaggerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Api", Version = "v1", Description = "School Services Api" });
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Oauth2 Authorization using the scheme.",
                Name = "Authorization",
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri($"{configuration["IdentityUrl"]}/connect/authorize"),
                        TokenUrl = new Uri($"{configuration["IdentityUrl"]}/connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            {"school", "School Api Services" }
                        }
                    }
                }
            });

            c.OperationFilter<AuthorizeCheckOperationFilter>();
        });

        return services;
    }
}
