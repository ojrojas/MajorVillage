namespace Core.Dtos;

public class CreateUserApplicationResponse : BaseResponse
{
	public CreateUserApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
	public bool UserApplicationCreated { get; set; }
}

