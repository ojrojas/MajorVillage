namespace Identity.Api.DI;

internal static class DISwaggerApplication
{
    public static IServiceCollection AddDISwaggerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity Api", Version = "v1", Description = "Identity Services Api" });
            c.AddSecurityDefinition("OAuth", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "OAuth authorization security scheme",
                Name = "Authorization",
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    ClientCredentials = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{configuration["IdentityUrl"]}/connect/authorize"),
                        TokenUrl = new Uri($"{configuration["IdentityUrl"]}/connect/token"),
                        Scopes = { { "identity", "Resource scope" } }
                    }
                }
            });

            /// add security requeriments
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                    },
                    Scheme = "oauth2",
                     In = ParameterLocation.Header
                },
                new List<string>()
            }
          });
        });

        return services;
    }
}
