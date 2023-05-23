namespace School.Api.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateElectiveYear :
    EndpointBaseAsync.WithRequest<CreateElectiveYearRequest>.WithResult<CreateElectiveYearResponse>
{
	private readonly IElectiveYearService _service;

    public CreateElectiveYear(IElectiveYearService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateElectiveYearResponse))]
    [SwaggerOperation(
     Summary = "Create Elective Year",
     Description = "Create Elective Year",
     OperationId = "ElectiveYear.createelectiveyear",
     Tags = new[] { "ElectiveYearEndpoints" })]
    public override async Task<CreateElectiveYearResponse> HandleAsync(CreateElectiveYearRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateElectiveYearAsync(request, cancellationToken);
    }
}