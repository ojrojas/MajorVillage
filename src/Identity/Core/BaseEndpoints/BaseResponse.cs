namespace Core.BaseEndpoints;

public class BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlationId) : base()
    {
        base.correlationId = correlationId;
    }
}