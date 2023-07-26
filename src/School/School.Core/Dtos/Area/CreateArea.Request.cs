namespace School.Core.Dtos;

public record CreateAreaRequest: BaseRequest
{
    public Area? Area { get; set; }
}