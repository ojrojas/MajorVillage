namespace School.Api.Endpoints.ElectiveYear;

[Authorize]
[Route("api/[controller]")]
public class UpdateElectiveYear : EndpointBaseAsync.WithRequest<UpdateElctiveYearRequest>.WithResult<UpdateElectiveYearResponse>
{
	private readonly IElectiveYearService _service;

    public UpdateElectiveYear(IElectiveYearService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [Consumes("application/json")]
    [Produces(typeof(UpdateElectiveYearResponse))]
    [SwaggerOperation(
     Summary = "Update Elective Year",
     Description = "Update Elective Year",
     OperationId = "ElectiveYear.updateelectiveyear",
     Tags = new[] { "ElectiveYearEndpoints" })]
    public override async Task<UpdateElectiveYearResponse> HandleAsync(UpdateElctiveYearRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.UpdateElectiveYearAsync(request, cancellationToken);
    }
}

