namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetAllTypeUsers : EndpointBaseAsync.WithRequest<GetAllTypeUsersRequest>.WithActionResult<GetAllTypeUserResponse>
{
    private readonly ITypeUserService _service;

    public GetAllTypeUsers(ITypeUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllTypeUserResponse))]
    [SwaggerOperation(
          Summary = "get all type users",
          Description = "get all type users",
          OperationId = "getalltypeuser.getall",
          Tags = new[] { "GetAllTypeUsers" })]
    public override async Task<ActionResult<GetAllTypeUserResponse>> HandleAsync(GetAllTypeUsersRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetAllTypeUsers(request, cancellationToken);
    }
}
