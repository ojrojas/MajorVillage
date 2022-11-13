namespace Api.EndPoints;

[AllowAnonymous]
[ApiController]
[Route("api/login")]
public class LoginUserApplication: EndpointBaseAsync.WithRequest<LoginUserApplicationRequest>.WithResult<LoginUserApplicationResponse>
{
    private readonly IUserApplicationService _service;

    public LoginUserApplication(IUserApplicationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(LoginUserApplicationResponse))]
    [SwaggerOperation(
        Summary = "Login user application",
        Description = "Login user",
        OperationId = "userapplication.loginuserapplication",
        Tags = new[] { "UserApplicationEndpoints" })]
    public override async Task<LoginUserApplicationResponse> HandleAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.LoginAsync(request, cancellationToken);
    }
}

