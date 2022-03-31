namespace MajorVillage.Core.Dtos;

public class UpdateUserResponse : BaseResponse
{
    public UpdateUserResponse() {}
    public UpdateUserResponse(Guid correlationId): base(correlationId){}
    public bool Updated {get;set;}
}