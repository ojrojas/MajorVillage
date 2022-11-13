namespace Core.Dtos;

public class CreateAddressResponse: BaseResponse
{
	public CreateAddressResponse(Guid CorrelationId): base(CorrelationId){}
	public Address AddressCreated { get; set; }
}

