using Microsoft.AspNetCore.Authorization;

namespace MajorVillage.Api.Endpoints;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class LoginUserApplication : EndpointBaseAsync.WithRequest<LoginUserApplicationRequest>.WithActionResult<LoginUserApplicationResponse>
{
    private readonly IUserApplicationService _service;

    public LoginUserApplication(IUserApplicationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [SwaggerOperation(  
          Summary = "login userapplication",
          Description = "login userapplication",
          OperationId = "applicationuser.login",
          Tags = new[] { "UserApplicationEndpoints" })]
    public override async Task<ActionResult<LoginUserApplicationResponse>> HandleAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.LoginUserApplication(request, cancellationToken);
    }
}
