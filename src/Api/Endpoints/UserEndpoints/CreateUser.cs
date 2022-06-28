namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateUser : EndpointBaseAsync.WithRequest<CreateUserRequest>.WithActionResult<CreateUserResponse>
{
    private readonly IUserService _service;

    private readonly ILogger<CreateUser> _logger;

    public CreateUser(ILogger<CreateUser> logger, IUserService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }
  
    [HttpPost]
    [ProducesResponseType(typeof(User), 200, "application/json")]
     [SwaggerOperation(
          Summary = "create user",
          Description = "Create user",
          OperationId = "user.create",
          Tags = new[] { "UserEndpoints" })]
    public async override Task<ActionResult<CreateUserResponse>> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Request create user request {request}");
        return await _service.CreateUserAsync(request, cancellationToken);
    }
}
