namespace Aggregator.Web.Api.DI;

public static class DIWebConfiguration
{
	public static WebApplication AddDIWebConfiguration(this WebApplication app)
	{
		app.MapGroup(string.Empty).AddAreaGroupRoute().WithTags("Area").RequireAuthorization();
        app.MapGroup(string.Empty).AddCourseGroupRoute().WithTags("Course").RequireAuthorization();
        app.MapGroup(string.Empty).AddClassRoomGroupRoute().WithTags("ClassRoom").RequireAuthorization();
        app.MapGroup(string.Empty).AddElectiveYearGroupRoute().WithTags("ElectiveYear").RequireAuthorization();
        app.MapGroup(string.Empty).AddEnrollmentGroupRoute().WithTags("Enrollment").RequireAuthorization();
        app.MapGroup(string.Empty).AddStudentGroupRoute().WithTags("Student").RequireAuthorization();
        app.MapGroup(string.Empty).AddSubjectGroupRoute().WithTags("Subject").RequireAuthorization();
        app.MapGroup(string.Empty).AddPeriodGroupRoute().WithTags("Period").RequireAuthorization();

        return app;
	}
}

