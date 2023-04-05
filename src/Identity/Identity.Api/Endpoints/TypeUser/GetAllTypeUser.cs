namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAllTypeUser : EndpointBaseAsync.WithoutRequest.WithResult<GetAllTypeUserResponse>
{
    private readonly ITypeUserService _service;

    public GetAllTypeUser(ITypeUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllTypeUserResponse))]
    [SwaggerOperation(
        Summary = "Get all type user",
        Description = "Get all type user",
        OperationId = "typeuser.getalltypeuser",
        Tags = new[] { "TypeUserEndpoints" })]
    public override async Task<GetAllTypeUserResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await _service.GetAllTypeUserAsync(new(), cancellationToken);
    }
}

