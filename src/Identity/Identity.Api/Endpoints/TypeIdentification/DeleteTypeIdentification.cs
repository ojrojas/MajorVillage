namespace Identity.Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeleteTypeIdentification : EndpointBaseAsync.WithRequest<DeleteTypeIdentificationRequest>.WithResult<DeleteTypeIdentificationResponse>
{
    private readonly ITypeIdentificationService _service;

    public DeleteTypeIdentification(ITypeIdentificationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete("{Id}")]
    [Produces(typeof(CreateTypeIdentificationResponse))]
    [SwaggerOperation(
      Summary = "Delete type identification",
      Description = "Delete type identification",
      OperationId = "typeidentification.deletetypeidentification",
      Tags = new[] { "TypeidentificationEndpoints" })]
    public override async Task<DeleteTypeIdentificationResponse> HandleAsync([FromRoute]DeleteTypeIdentificationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteTypeIdentificationAsync(request, cancellationToken);
    }
}

