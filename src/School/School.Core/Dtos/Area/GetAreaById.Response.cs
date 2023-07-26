namespace School.Core.Dtos;

public record GetAreaByIdResponse : BaseResponse
{
    public GetAreaByIdResponse(Guid correlationId) : base(correlationId)
    {
    }

    public Area? Area { get; set; }
}