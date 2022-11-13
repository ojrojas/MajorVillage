namespace Api.DI
{
    internal static class AddServicesDependecyInjection
    {
        internal static IServiceCollection AddServicesDIApp(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddTransient<ITypeIdentificationService, TypeIdentificationService>();
            //services.AddTransient<ITypeUserService, TypeUserService>();
            //services.AddTransient<IUserService, UserService>();
           // services.AddTransient<IUserApplicationService, UserApplicationService>();

            return services;
        }
    }
}
