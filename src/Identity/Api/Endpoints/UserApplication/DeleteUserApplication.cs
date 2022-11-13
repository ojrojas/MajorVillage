namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeleteUserApplication : EndpointBaseAsync.WithRequest<DeleteUserApplicationRequest>.WithResult<DeleteUserApplicationResponse>
{
    private readonly IUserApplicationService _service;

    public DeleteUserApplication(IUserApplicationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete("{Id}")]
    [Produces(typeof(DeleteUserApplicationResponse))]
    [SwaggerOperation(
        Summary = "Delete user application",
        Description = "Delete user application",
        OperationId = "userapplication.deleteuserapplication",
        Tags = new[] { "UserApplicationEndpoints" })]
    public override async Task<DeleteUserApplicationResponse> HandleAsync([FromRoute]DeleteUserApplicationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteUserApplicationAsync(request, cancellationToken);
    }
}

