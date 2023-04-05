namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAllTypeIdentification : EndpointBaseAsync.WithoutRequest.WithResult<GetAllTypeIdentificationResponse>
{
    private readonly ITypeIdentificationService _service;

    public GetAllTypeIdentification(ITypeIdentificationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllTypeIdentificationResponse))]
    [SwaggerOperation(
    Summary = "Get all type identification",
    Description = "Get all  type identification",
    OperationId = "typeidentification.getalltypeidentification",
    Tags = new[] { "TypeidentificationEndpoints" })]
    public override async Task<GetAllTypeIdentificationResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await _service.GetAllTypeIdentificationAsync(new(), cancellationToken);
    }
}

