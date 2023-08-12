namespace Aggregator.Web.Api.DI;

public static class DIServiceApplication
{
	public static IServiceCollection AddDIServiceApplication(this IServiceCollection services)
	{
		services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));
		services.AddTransient<IAreaService, Services.AreaService>();
        services.AddTransient<ICourseService, Services.CourseService>();
        services.AddTransient<IClassRoomService, Services.ClassRoomService>();
        services.AddTransient<IEnrollmentService, Services.EnrollmentService>();
        services.AddTransient<IElectiveYearService, Services.ElectiveYearService>();
        services.AddTransient<IStudentService, Services.StudentService>();
        services.AddTransient<IPeriodService, Services.PeriodService>();
        services.AddTransient<ISubjectService, Services.SubjectService>();

        return services;
	}
}

