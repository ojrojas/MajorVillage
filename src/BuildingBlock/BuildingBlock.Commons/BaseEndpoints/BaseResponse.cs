namespace BuildingBlock.Commons.BaseEndpoints;

public record BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlationId) : base()
    {
        _correlationId = correlationId;
    }
}