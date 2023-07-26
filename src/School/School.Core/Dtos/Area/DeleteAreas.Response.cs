namespace School.Core.Dtos;

public record DeleteAreaResponse: BaseResponse
{
	public DeleteAreaResponse(Guid correlationId): base(correlationId)
	{
	}

	public bool IsAreaDeleted { get; set; }
}