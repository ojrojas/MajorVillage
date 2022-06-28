namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetPermission : EndpointBaseAsync.WithRequest<PermissionManagerRequest>.WithActionResult<PermissionManagerResponse>
{
    private readonly IPermissionManagerService _service;
    private readonly ILogger<GetPermission> _logger;

    public GetPermission(IPermissionManagerService service, ILogger<GetPermission> logger)
    {
        _service = service ?? throw new ArgumentException(nameof(service));
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }

    [HttpGet]
    [Produces(typeof(PermissionManagerResponse))]
    [SwaggerOperation(
              Summary = "get all permissions project",
              Description = "get all permission",
              OperationId = "permission.getpermission",
              Tags = new[] { "Permission" })]
    public override async Task<ActionResult<PermissionManagerResponse>> HandleAsync(PermissionManagerRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Request get all premissions request {request}");
        return await _service.GetPermission(request, cancellationToken);
    }
}