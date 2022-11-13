namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAllAddress : EndpointBaseAsync.WithoutRequest.WithResult<GetAllAddressResponse>
{
    private readonly IAddressService _service;

    public GetAllAddress(IAddressService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Produces(typeof(GetAllAddressResponse))]
    [SwaggerOperation(
    Summary = "Get all address",
    Description = "Get all address",
    OperationId = "Address.getalladdress",
    Tags = new[] { "AddressEndpoints" })]
    public override async Task<GetAllAddressResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        return await _service.GetAllAddressAsync(new(), cancellationToken);
    }
}

