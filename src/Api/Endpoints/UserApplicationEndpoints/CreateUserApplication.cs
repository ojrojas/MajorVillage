namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateUserApplication : EndpointBaseAsync.WithRequest<CreateUserApplicationRequest>.WithActionResult<CreateUserApplicationResponse>
{
    private readonly IUserApplicationService _service;
    private readonly ILogger<CreateUserApplication> _logger;

    public CreateUserApplication(IUserApplicationService service, ILogger<CreateUserApplication> logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpPost]
    [Produces(typeof(CreateUserApplicationResponse))]
    [SwaggerOperation(
          Summary = "create userapplication",
          Description = "create userapplication",
          OperationId = "applicationuser.create",
          Tags = new[] { "UserApplicationEndpoints" })]
    public override async Task<ActionResult<CreateUserApplicationResponse>> HandleAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Create user application request {request}");
        return await _service.CreateUserApplication(request, cancellationToken);
    }
}
