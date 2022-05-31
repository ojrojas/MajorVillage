namespace MajorVillage.Core.Dtos;

public class PermissionManagerResponse : BaseResponse
{
    public PermissionManagerResponse(Guid CorrelationId): base(CorrelationId){}
    public PermissionManager PermissionManager { get; set; }
}