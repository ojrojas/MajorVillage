using Microsoft.EntityFrameworkCore;

namespace School.Api.DI;

public static class DIDbContextApplication
{
    public static IServiceCollection AddDIDbContextApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // 11.0.2
        var serverVersion = new MariaDbServerVersion(new Version(11, 0, 2));
        services.AddDbContext<SchoolDbContext>(c => c.UseMySql(configuration["ConnectionSchool"], serverVersion));
        return services;
    }
}