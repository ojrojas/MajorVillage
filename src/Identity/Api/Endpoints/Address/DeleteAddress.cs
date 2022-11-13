namespace Api.EndPoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeleteAddress : EndpointBaseAsync.WithRequest<DeleteAddressRequest>.WithResult<DeleteAddressResponse>
{
    private readonly IAddressService _service;

    public DeleteAddress(IAddressService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete("{Id}")]
    [Produces(typeof(CreateAddressResponse))]
    [SwaggerOperation(
      Summary = "Delete address",
      Description = "Delete address",
      OperationId = "address.deleteaddress",
      Tags = new[] { "AddressEndpoints" })]
    public override async Task<DeleteAddressResponse> HandleAsync([FromRoute]DeleteAddressRequest request, CancellationToken cancellationToken = default)
    {
        return await _service.DeleteAddressAsync(request, cancellationToken);
    }
}

