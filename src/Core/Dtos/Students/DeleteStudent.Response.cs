namespace MajorVillage.Core.Dtos;

public class DeleteStudentResponse : BaseResponse
{
    public DeleteStudentResponse(){} 
    public DeleteStudentResponse(Guid correlationId): base(correlationId) { }
    public bool Deleted { get; set; }
}