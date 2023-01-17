namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateTypeIdentification : EndpointBaseAsync.WithRequest<CreateTypeIdentificationRequest>.WithResult<CreateTypeIdentificationResponse>
{
    private readonly ITypeIdentificationService _service;

    public CreateTypeIdentification(ITypeIdentificationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateTypeIdentificationResponse))]
    [SwaggerOperation(
      Summary = "Create type identification",
      Description = "Create type identification",
      OperationId = "typeidentification.createtypeidentification",
      Tags = new[] { "TypeidentificationEndpoints" })]
    public override async Task<CreateTypeIdentificationResponse> HandleAsync(CreateTypeIdentificationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateTypeIdentificationAsync(request, cancellationToken);
    }
}

