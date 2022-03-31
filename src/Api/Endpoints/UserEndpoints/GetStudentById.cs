namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetUserById : EndpointBaseAsync.WithRequest<GetUserByIdRequest>.WithActionResult<GetUserByIdResponse>
{
    private readonly IUserService _service;

    private readonly ILogger<GetUserById> _logger;

    public GetUserById(ILogger<GetUserById> logger, IUserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(User), 200, "application/json")]
    [SwaggerOperation(
          Summary = "get user user by id",
          Description = "Get user by Identifier",
          OperationId = "user.getbyid",
          Tags = new[] { "UserEndpoints" })]
    public async override Task<ActionResult<GetUserByIdResponse>> HandleAsync([FromRoute] GetUserByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetUserByIdAsync(request, cancellationToken);
    }
}
