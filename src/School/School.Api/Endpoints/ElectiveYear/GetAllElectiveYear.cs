namespace School.Api.Endpoints.ElectiveYear;

[Authorize]
[Route("api/[controller]")]
public class GetAllElectiveYear : EndpointBaseAsync.WithRequest<GetAllElectiveYearRequest>.WithResult<GetAllElectiveYearResponse>
{
    private readonly IElectiveYearService _service;

    public GetAllElectiveYear(IElectiveYearService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllElectiveYearResponse))]
    [SwaggerOperation(
     Summary = "Get all Elective Year",
     Description = "Get all Elective Year",
     OperationId = "ElectiveYear.getelectiveyear",
     Tags = new[] { "ElectiveYearEndpoints" })]
    public override async Task<GetAllElectiveYearResponse> HandleAsync(GetAllElectiveYearRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetAllElectiveYearsAsync(request, cancellationToken);
    }
}

