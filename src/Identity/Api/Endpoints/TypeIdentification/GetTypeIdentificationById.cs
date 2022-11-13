namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetTypeIdentificationById : EndpointBaseAsync.WithRequest<GetTypeIdentificationByIdRequest>.WithResult<GetTypeIdentificationByIdResponse>
{
    private readonly ITypeIdentificationService _service;

    public GetTypeIdentificationById(ITypeIdentificationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{Id}")]
    [Produces(typeof(GetTypeIdentificationByIdResponse))]
    [SwaggerOperation(
    Summary = "Get type identification by id ",
    Description = "Get type identification by id",
    OperationId = "typeidentification.getalltypeidentification",
    Tags = new[] { "TypeidentificationEndpoints" })]
    public override async Task<GetTypeIdentificationByIdResponse> HandleAsync([FromRoute]GetTypeIdentificationByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetTypeIdentificationByIdAsync(request, cancellationToken);
    }
}

