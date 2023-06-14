namespace School.Api.Endpoints.ElectiveYear;

[Authorize]
[Route("api/[controller]")]
public class DeleteElectiveYear: EndpointBaseAsync.WithRequest<DeleteElectiveYearRequest>.WithResult<DeleteElectiveYearResponse>
{
    private readonly IElectiveYearService _service;

    public DeleteElectiveYear(IElectiveYearService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete]
    [Consumes("application/json")]
    [Produces(typeof(DeleteElectiveYearResponse))]
    [SwaggerOperation(
     Summary = "Delete Elective Year",
     Description = "Delete Elective Year",
     OperationId = "ElectiveYear.deleteelectiveyear",
     Tags = new[] { "ElectiveYearEndpoints" })]
    public override async Task<DeleteElectiveYearResponse> HandleAsync(DeleteElectiveYearRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteElectiveYearAsync(request, cancellationToken);
    }
}

