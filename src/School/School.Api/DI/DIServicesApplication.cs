namespace School.Api.DI;

internal static class DIServicesApplication
{
    internal static IServiceCollection AddServicesDIApplication(this IServiceCollection services)
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
