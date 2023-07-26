namespace School.Core.Dtos;

public record DeleteAreaRequest: BaseRequest
{
    public Guid Id { get; set; }
}