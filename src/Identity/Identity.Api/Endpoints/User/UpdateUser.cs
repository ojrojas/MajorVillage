namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UpdateUser : EndpointBaseAsync.WithRequest<UpdateUserRequest>.WithResult<UpdateUserResponse>
{
    private readonly IUserService _service;

    public UpdateUser(IUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [Produces(typeof(UpdateUserResponse))]
    [SwaggerOperation(
       Summary = "Update user",
       Description = "Update user",
       OperationId = "user.updateuser",
       Tags = new[] { "UserEndpoints" })]
    public override async Task<UpdateUserResponse> HandleAsync(UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.UpdateUserAsync(request, cancellationToken);
    }
}