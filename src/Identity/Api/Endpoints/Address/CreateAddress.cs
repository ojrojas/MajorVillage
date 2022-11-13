namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateAddress : EndpointBaseAsync.WithRequest<CreateAddressRequest>.WithResult<CreateAddressResponse>
{
    private readonly IAddressService _service;

    public CreateAddress(IAddressService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Produces(typeof(CreateAddressResponse))]
    [SwaggerOperation(
      Summary = "Create address",
      Description = "Create address",
      OperationId = "address.createaddress",
      Tags = new[] { "AddressEndpoints" })]
    public override async Task<CreateAddressResponse> HandleAsync(CreateAddressRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.CreateAddressAsync(request, cancellationToken);
    }
}

