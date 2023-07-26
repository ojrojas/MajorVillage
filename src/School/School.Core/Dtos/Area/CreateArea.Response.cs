namespace School.Core.Dtos;

public record CreateAreaResponse: BaseResponse
{
	public CreateAreaResponse(Guid correlationId): base(correlationId) { }
	public Area? AreaCreated { get; set; }
}