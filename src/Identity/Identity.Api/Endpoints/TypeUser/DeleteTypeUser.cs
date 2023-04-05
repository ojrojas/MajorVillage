namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeleteTypeUser : EndpointBaseAsync.WithRequest<DeleteTypeUserRequest>.WithResult<DeleteTypeUserResponse>
{
    private readonly ITypeUserService _service;

    public DeleteTypeUser(ITypeUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete("{Id}")]
    [Produces(typeof(DeleteTypeUserResponse))]
    [SwaggerOperation(
        Summary = "Delete type user",
        Description = "Delete type user",
        OperationId = "typeuser.deletetypeuser",
        Tags = new[] { "TypeUserEndpoints" })]
    public override async Task<DeleteTypeUserResponse> HandleAsync([FromRoute]DeleteTypeUserRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteTypeUserAsync(request, cancellationToken);
    }
}

