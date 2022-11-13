namespace Core.Dtos;

public class GetAllAddressResponse: BaseResponse
{
	public GetAllAddressResponse(Guid CorrelationId): base(CorrelationId)
	{
	}

	public IEnumerable<Address> Addresss { get; set; }
}

