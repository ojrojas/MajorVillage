namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetUserById : EndpointBaseAsync.WithRequest<GetUserByIdRequest>.WithResult<GetUserByIdResponse>
{
    private readonly IUserService _service;

    public GetUserById(IUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{Id}")]
    [Produces(typeof(GetUserByIdResponse))]
    [SwaggerOperation(
     Summary = "get user by id",
     Description = "Get user by id",
     OperationId = "typeuser.getuserbyid",
     Tags = new[] { "UserEndpoints" })]
    public override async Task<GetUserByIdResponse> HandleAsync(GetUserByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetUserByIdAsync(request, cancellationToken);
    }
}

