namespace Identity.Api.DI;

internal static class DIServicesApplication
{
    public static IServiceCollection AddDIServicesApplication(this IServiceCollection services)
    {
        services.AddTransient(typeof(TypeIdentificationRepository));
        services.AddTransient(typeof(UserApplicationRepository));
        services.AddTransient(typeof(TypeUserRepository));
        services.AddTransient(typeof(AttendantRepository));

        services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));
        services.AddTransient<ITypeIdentificationService, TypeIdentificationService>();
        services.AddTransient<ITypeUserService, TypeUserService>();
        services.AddTransient<IUserApplicationService, UserApplicationService>();
        services.AddTransient<IAttendantService, AttendantService>();

        services.AddTransient<InitializerDbContext>();

        return services;
    }
}