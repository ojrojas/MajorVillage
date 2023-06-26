using Identity.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Api.DI;

public static class IdentityServerApplication
{
    public static IServiceCollection AddIdentityServerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
      
        services.AddIdentity<UserApplication, IdentityRole>()
            .AddEntityFrameworkStores<IdentityAppDbContext>()
            .AddDefaultTokenProviders();
        try
        {
            services.AddIdentityServer(x =>
            {
                x.IssuerUri = "null";
                x.Authentication.CookieLifetime = TimeSpan.FromHours(2);
            })
            .AddSigningCredential(Certificate.GetCert())
            //.AddInMemoryApiResources(IdentityConfig.GetApis())
            //.AddInMemoryIdentityResources(IdentityConfig.GetResources())
            //.AddInMemoryClients(IdentityConfig.GetClients(clientsUrls))
            .AddAspNetIdentity<UserApplication>()
            .AddConfigurationStore(op =>
            {
                op.ConfigureDbContext = builder => builder.UseSqlite(configuration.GetConnectionString("ConnectionSqlite"),
                sqliteOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                });
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlite(configuration.GetConnectionString("ConnectionSqlite"),
                sqliteOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                });
            });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }

        return services;
    }
}

