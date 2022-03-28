namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class LoginUserApplication : EndpointBaseAsync.WithRequest<LoginUserApplicationRequest>.WithActionResult<LoginUserApplicationResponse>
{
    private readonly IUserApplicationService _service;

    public LoginUserApplication(IUserApplicationService service)
    {
        _service = service;
    }

    [HttpPost]
    public override async Task<ActionResult<LoginUserApplicationResponse>> HandleAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.LoginUserApplication(request, cancellationToken);
    }
}
