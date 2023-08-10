namespace Aggregator.Web.Api.DI;

public static class AddGrpcServiceApp
{
    /// <summary>
    /// Add grpc services
    /// </summary>
    /// <param name="services">Collection services</param>
    /// <param name="configuration">configuration application</param>
    /// <returns>Collection services configurated</returns>
    public static IServiceCollection AddGrpcServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<GrpcExceptionInterceptor>();

        services.AddScoped<IAreaService, Services.AreaService>();

        services.AddGrpcClient<GrpcSchool.AreaService.AreaServiceClient>(options => {
            var urlbase = configuration.GetValue("GRPC_URL", "http://localhost:5108");
            options.Address = new Uri(urlbase);
        }).AddInterceptor<GrpcExceptionInterceptor>();

        return services;
    }
}