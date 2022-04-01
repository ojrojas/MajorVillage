namespace MajorVillage.Api.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class GetElectiveYearById : EndpointBaseAsync.WithRequest<GetElectiveYearByIdRequest>.WithActionResult<GetElectiveYearByIdResponse>
{
    private readonly IElectiveYearService _service;

    public GetElectiveYearById(IElectiveYearService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
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
        return await _service.GetElectiveYearById(request, cancellationToken);
    }
}
