namespace Core.Dtos;

public class UpdateAddressResponse: BaseResponse
{
	public UpdateAddressResponse(Guid CorrelationId) : base(CorrelationId){}
	public Address AddressUpdated{ get; set; }
}

