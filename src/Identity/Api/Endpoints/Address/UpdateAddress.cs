namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UpdateAddress : EndpointBaseAsync.WithRequest<UpdateAddressRequest>.WithResult<UpdateAddressResponse>
{
    private readonly IAddressService _service;

    public UpdateAddress(IAddressService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [Produces(typeof(UpdateAddressResponse))]
    [SwaggerOperation(
     Summary = "Update address",
     Description = "Update address",
     OperationId = "Address.updateaddress",
     Tags = new[] { "AddressEndpoints" })]
    public override async Task<UpdateAddressResponse> HandleAsync(UpdateAddressRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.UpdateAddressAsync(request, cancellationToken);
    }
}

