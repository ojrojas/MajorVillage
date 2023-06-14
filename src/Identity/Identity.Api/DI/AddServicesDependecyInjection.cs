namespace Identity.Api.DI;

internal static class AddServicesDependecyInjection
{
    public static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddTransient(typeof(GenericRepository<>));

        services.AddTransient(typeof(TypeIdentificationRepository));
        services.AddTransient(typeof(UserRepository));
        services.AddTransient(typeof(UserApplicationRepository));
        services.AddTransient(typeof(TypeUserRepository));

        services.AddTransient(typeof(ITokenService<>), typeof(TokenService<>));

        services.AddTransient<IEncryptService, EncryptService>();
        services.AddTransient<ITypeIdentificationService, TypeIdentificationService>();
        services.AddTransient<ITypeUserService, TypeUserService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserApplicationService, UserApplicationService>();

        services.AddTransient<InitializerDbContext>();

        return services;
    }
}