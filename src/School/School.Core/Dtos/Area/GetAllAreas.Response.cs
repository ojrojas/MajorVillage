namespace School.Core.Dtos;

public record GetAllAreasResponse: BaseResponse
{
    public GetAllAreasResponse(Guid correlationId): base(correlationId) { }
    public IEnumerable<Area>? Areas { get; set; }
}