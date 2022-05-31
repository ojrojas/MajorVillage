namespace MajorVillage.Core.Dtos;

public class PermissionManagerActionResponse : BaseResponse
{
    public PermissionManagerActionResponse(Guid CorrelationId) : base(CorrelationId) { }

    public PermissionAction PermissionAction { get; set; }
}