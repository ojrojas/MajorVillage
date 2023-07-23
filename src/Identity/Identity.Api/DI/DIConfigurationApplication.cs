namespace Identity.Api.DI;

public static class DIConfigurationApplication
{
    public static WebApplication AddDIConfigurationApplication(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.MapDefaultControllerRoute();

        app.MapGroup(string.Empty).AddAuthorizationGroupRoute();
        app.MapGroup("/api").AddAttendantGroupRoute();
        app.MapGroup("/api").AddTypeIdentificationGroupRoute();
        app.MapGroup("/api").AddTypeUserGroupRoute();
        app.MapGroup("/api").AddUserApplicationGroupRoute();

        return app;
    }
}

