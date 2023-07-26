namespace School.Core.Dtos;

public record UpdateAreaResponse: BaseResponse
{
	public UpdateAreaResponse(Guid correlationId): base(correlationId)
	{
	}

	public Area? AreaUpdated { get; set; }
}