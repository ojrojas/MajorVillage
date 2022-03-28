namespace MajorVillage.Api.Extensions;
internal static class AddExtensionInjectDependencies
{
    public static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IDapperRepository<>), typeof(DapperRepository<>));
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<IUserApplicationService, UserApplicationService>();
        services.AddTransient<IUserApplicationRepository, UserApplicationRepository>();
        services.AddTransient<IEncryptPassFunctionality, EncryptPassFunctionality>();

        return services;
    }
    
}