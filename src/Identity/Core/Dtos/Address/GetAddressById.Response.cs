namespace Core.Dtos;

public class GetAddressByIdResponse: BaseResponse
{
	public GetAddressByIdResponse(Guid CorrelationId): base(CorrelationId){}
	public Address Address { get; set; }

}

