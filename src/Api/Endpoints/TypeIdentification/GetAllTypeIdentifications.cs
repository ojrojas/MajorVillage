namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetAllTypeIdentifications : EndpointBaseAsync.WithRequest<GetAllTypeIdentificationRequest>.WithActionResult<GetAllTypeIdentificationResponse>
{
    private readonly ITypeIdentificationService _service;

    public GetAllTypeIdentifications(ITypeIdentificationService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllTypeUserResponse))]
    [SwaggerOperation(
          Summary = "get all type Identification",
          Description = "get all type Identification",
          OperationId = "getalltypeuser.getalltypeidentification",
          Tags = new[] { "GetAllTypeIdentification" })]
    public override async Task<ActionResult<GetAllTypeIdentificationResponse>> HandleAsync(GetAllTypeIdentificationRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetAllTypeIdentifications(request, cancellationToken);
    }
}
