namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateUserApplication : EndpointBaseAsync.WithRequest<CreateUserApplicationRequest>.WithActionResult<CreateUserApplicationResponse>
{
    private readonly IUserApplicationService _service;

    public CreateUserApplication(IUserApplicationService service)
    {
        _service = service;
    }

    [HttpPost]
     [SwaggerOperation(
          Summary = "create userapplication",
          Description = "create userapplication",
          OperationId = "applicationuser.create",
          Tags = new[] { "UserApplicationEndpoints" })]
    public override async Task<ActionResult<CreateUserApplicationResponse>> HandleAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken = default)
    {
     return await _service.CreateUserApplication(request,cancellationToken);  
    }
}
