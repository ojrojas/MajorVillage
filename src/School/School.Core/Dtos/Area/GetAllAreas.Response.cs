namespace School.Core.Dtos;

public record GetAllAreaResponse: BaseRequest
{
    public IEnumerable<Area>? Areas { get; set; }
}