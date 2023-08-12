namespace School.Api.DI;

internal static class DIServicesApplication
{
    internal static IServiceCollection AddServicesDIApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AreaMapper));
        services.AddTransient(typeof(CourseRepository));
        services.AddTransient(typeof(ElectiveYearRepository));
        services.AddTransient(typeof(EnrollmentRepository));
        services.AddTransient(typeof(ClassRoomRepository));
        services.AddTransient(typeof(AreaRepository));

        services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));

        //services.AddTransient<ICourseService, CourseService>();
        //services.AddTransient<IEnrollmentService, EnrollmentService>();
        //services.AddTransient<IElectiveYearService, ElectiveYearService>();
        //services.AddTransient<IClassRoomService, ClassRoomService>();
        services.AddTransient<IAreaService, Core.Services.AreaService>();

        services.AddTransient<InitializerDbContext>();
        return services;
    }
}
