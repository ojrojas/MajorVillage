using Ardalis.Specification;

namespace School.Api.DI;

internal static class AddServicesDependecyInjection
{
    internal static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddTransient(typeof(GenericRepository<>));

        services.AddTransient(typeof(CourseRepository));
        services.AddTransient(typeof(ElectiveYearRepository));
        services.AddTransient(typeof(EnrollmentRepository));

        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<IEnrollmentService, EnrollmentService>();
        services.AddTransient<IElectiveYearService, ElectiveYearService>();

        services.AddTransient<InitializerDbContext>();
        return services;
    }
}
