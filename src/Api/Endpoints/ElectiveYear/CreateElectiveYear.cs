namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class CreateElectiveYear : EndpointBaseAsync.WithRequest<CreateElectiveYearRequest>.WithActionResult<CreateElectiveYearResponse>
{
    private readonly IElectiveYearService _service;
    private readonly ILogger<CreateElectiveYear> _Logger;

    public CreateElectiveYear(IElectiveYearService service, ILogger<CreateElectiveYear> logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _Logger = logger ?? throw new ArgumentException(nameof(logger));
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
        _Logger.LogInformation($"CreateElectiveYear request data {request}");
        return await _service.CreateElectiveYear(request, cancellationToken);
    }
}
