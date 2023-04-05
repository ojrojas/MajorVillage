namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAllUser : EndpointBaseAsync.WithoutRequest.WithResult<GetAllUserResponse>
{
    private readonly IUserService _service;

    public GetAllUser(IUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllUserResponse))]
    [SwaggerOperation(
      Summary = "get all user",
      Description = "Get all  user",
      OperationId = "user.getalluser",
      Tags = new[] { "UserEndpoints" })]
    public override async Task<GetAllUserResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await _service.GetAllUserAsync(new(), cancellationToken);
    }
}

