namespace MajorVillage.Api.Extensions;
internal static class AddExtensionInjectDependencies
{
    public static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IDapperRepository<>), typeof(DapperRepository<>));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserApplicationService, UserApplicationService>();
        services.AddTransient<IUserApplicationRepository, UserApplicationRepository>();
        services.AddTransient<IEncryptPassFunctionality, EncryptPassFunctionality>();

        return services;
    }
    
}