namespace Core.Dtos;

public record CreateUserApplicationResponse : BaseResponse
{
	public CreateUserApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
	public bool UserApplicationCreated { get; set; }
}

