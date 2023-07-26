namespace School.Core.Dtos;

public record UpdateAreaRequest: BaseRequest
{
    public Area? Area { get; set; }
}