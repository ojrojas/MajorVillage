namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetAddressById : EndpointBaseAsync.WithRequest<GetAddressByIdRequest>.WithResult<GetAddressByIdResponse>
{
    private readonly IAddressService _service;

    public GetAddressById(IAddressService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{Id}")]
    [Produces(typeof(GetAddressByIdResponse))]
    [SwaggerOperation(
    Summary = "Get address by id ",
    Description = "Get address by id",
    OperationId = "Address.getalladdress",
    Tags = new[] { "AddressEndpoints" })]
    public override async Task<GetAddressByIdResponse> HandleAsync([FromRoute]GetAddressByIdRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.GetAddressByIdAsync(request, cancellationToken);
    }
}

