namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetElectiveYearById : EndpointBaseAsync.WithRequest<GetElectiveYearByIdRequest>.WithActionResult<GetElectiveYearByIdResponse>
{
    private readonly IElectiveYearService _service;
    private readonly ILogger<GetElectiveYearById> _logger;

    public GetElectiveYearById(IElectiveYearService service, ILogger<GetElectiveYearById> logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [Produces(typeof(GetElectiveYearByIdResponse))]
    [SwaggerOperation(
          Summary = "Get elective by id",
          Description = "get elective by id",
          OperationId = "electiveyear.getelectivebyid",
          Tags = new[] { "ElectiveYearEndpoints" })]
    public override async Task<ActionResult<GetElectiveYearByIdResponse>> HandleAsync(GetElectiveYearByIdRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"GetElectiveYear request {request}");
        return await _service.GetElectiveYearById(request, cancellationToken);
    }
}
