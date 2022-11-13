namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UpdateTypeIdentification : EndpointBaseAsync.WithRequest<UpdateTypeIdentificationRequest>.WithResult<UpdateTypeIdentificationResponse>
{
    private readonly ITypeIdentificationService _service;

    public UpdateTypeIdentification(ITypeIdentificationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [Produces(typeof(UpdateTypeIdentificationResponse))]
    [SwaggerOperation(
     Summary = "Update type identification",
     Description = "Update type identification",
     OperationId = "typeidentification.updatetypeidentification",
     Tags = new[] { "TypeidentificationEndpoints" })]
    public override async Task<UpdateTypeIdentificationResponse> HandleAsync(UpdateTypeIdentificationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.UpdateTypeIdentificationAsync(request, cancellationToken);
    }
}

