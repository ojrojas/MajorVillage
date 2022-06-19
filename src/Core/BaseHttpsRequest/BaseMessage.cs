namespace MajorVillage.Core.BaseHttpsRequest;

/// <summary>
/// Base correlation request
/// </summary>
/// <author>Oscar Julian Rojas</author>
public abstract class BaseMessage
{
    /// <summary>
    /// Base Identifier request 
    /// </summary>
    protected Guid _correlationId = Guid.NewGuid();

    public Guid CorrelationId() => _correlationId;
}