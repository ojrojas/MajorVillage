namespace MajorVillage.Core.Dtos;

public class UpdateStudentResponse : BaseResponse
{
    public UpdateStudentResponse() {}
    public UpdateStudentResponse(Guid correlationId): base(correlationId){}
    public bool Updated {get;set;}
}