namespace BuildingBlocks.Commons.BaseEndpoints;

public abstract record BaseMessage
{
    protected Guid correlationId = Guid.NewGuid();
    public Guid CorrelationId() => correlationId;
}