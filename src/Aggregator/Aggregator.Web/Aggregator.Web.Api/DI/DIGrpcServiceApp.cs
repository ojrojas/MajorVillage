namespace Aggregator.Web.Api.DI;

public static class DIGrpcServiceApp
{
    /// <summary>
    /// Add grpc services
    /// </summary>
    /// <param name="services">Collection services</param>
    /// <param name="configuration">configuration application</param>
    /// <returns>Collection services configurated</returns>
    public static IServiceCollection AddDIGrpcServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.AreaService.AreaServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.CourseService.CourseServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.ClassRoomService.ClassRoomServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.ElectiveYearService.ElectiveYearServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.EnrollmentService.EnrollmentServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.PeriodService.PeriodServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.StudentService.StudentServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        services.AddGrpcClient<GrpcSchool.SubjectService.SubjectServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();


        return services;
    }
}