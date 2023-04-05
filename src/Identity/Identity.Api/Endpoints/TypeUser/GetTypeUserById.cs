namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetTypeUserById : EndpointBaseAsync.WithRequest<GetTypeUserByIdRequest>.WithResult<GetTypeUserByIdResponse>
{
    private readonly ITypeUserService _service;

    public GetTypeUserById(ITypeUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{Id}")]
    [Produces(typeof(GetTypeUserByIdResponse))]
    [SwaggerOperation(
        Summary = "Get type user by id",
        Description = "Get type user by id ",
        OperationId = "typeuser.gettypeuserbyid",
        Tags = new[] { "TypeUserEndpoints" })]
    public override async Task<GetTypeUserByIdResponse> HandleAsync([FromRoute]GetTypeUserByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetTypeUserByIdAsync(request, cancellationToken);
    }
}

