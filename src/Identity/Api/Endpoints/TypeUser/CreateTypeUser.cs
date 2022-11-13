namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateTypeUser : EndpointBaseAsync.WithRequest<CreateTypeUserRequest>.WithResult<CreateTypeUserResponse>
{
    private readonly ITypeUserService _service;

    public CreateTypeUser(ITypeUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateTypeUserResponse))]
    [SwaggerOperation(
        Summary = "Create type user",
        Description = "Create type user",
        OperationId = "typeuser.createtypeuser",
        Tags = new[] { "TypeUserEndpoints" })]
    public override async Task<CreateTypeUserResponse> HandleAsync(CreateTypeUserRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateTypeUserAsync(request, cancellationToken);
    }
}

