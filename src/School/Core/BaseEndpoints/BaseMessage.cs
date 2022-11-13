namespace Core.BaseEndpoints;

public abstract class BaseMessage
{
    protected Guid correlationId = Guid.NewGuid();
    public Guid CorrelationId() => correlationId;
}