namespace MajorVillage.Core.Dtos;

public class DeleteUserResponse : BaseResponse
{
    public DeleteUserResponse(){} 
    public DeleteUserResponse(Guid correlationId): base(correlationId) { }
    public bool Deleted { get; set; }
}