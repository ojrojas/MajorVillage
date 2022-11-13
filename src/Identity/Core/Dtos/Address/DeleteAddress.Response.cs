namespace Core.Dtos;

public class DeleteAddressResponse: BaseResponse
{
	public DeleteAddressResponse(Guid CorrelationId): base(CorrelationId){	}
	public Address AddressDeleted { get; set; }
}

