namespace Identity.Api.DI;

public static class DIContextApplication
	{
		public static IServiceCollection AddDIContextApplication(this IServiceCollection services, IConfiguration configuration)
		{

        services.AddDbContext<IdentityAppDbContext>(
            opt => {
                opt.UseNpgsql(configuration.GetSection("ConnectionIdentity").Value, optActions =>
                {
                    optActions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                });

                opt.UseOpenIddict();
            });

        return services;
		}
	}

