namespace Identity.Api.GroupsEndpoints;

public static class UserApplicationGroupRoute
{
	public static RouteGroupBuilder AddUserApplicationGroupRoute(this RouteGroupBuilder group)
	{
		group.WithTags("UserApplicationEndpoints");

		group.MapGet("GetAllUsers",[Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
		async ([FromServices] IUserApplicationService _service,CancellationToken cancellationToken ) =>
		{
			return await _service.GetAllUserApplicationsAsync(new(), cancellationToken);
		});



		return group;
	}
}

