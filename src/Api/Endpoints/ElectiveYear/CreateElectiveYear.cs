namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateElectiveYear : EndpointBaseAsync.WithRequest<CreateElectiveYearRequest>.WithActionResult<CreateElectiveYearResponse>
{
    private readonly IElectiveYearService _service;

    public CreateElectiveYear(IElectiveYearService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateElectiveYearResponse))]
    [SwaggerOperation(
          Summary = "Create elective year",
          Description = "Create elective year",
          OperationId = "electiveyear.createelective",
          Tags = new[] { "ElectiveYearEndpoints" })]
    public override async Task<ActionResult<CreateElectiveYearResponse>> HandleAsync(CreateElectiveYearRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateElectiveYear(request, cancellationToken);
    }
}
