namespace BuildingBlocks.Commons.BaseEndpoints;

public record BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlationId) : base()
    {
        base.correlationId = correlationId;
    }
}