namespace MajorVillage.Core.Dtos;

public class CreateStudentResponse : BaseResponse
{
    public CreateStudentResponse(Guid correlationId) : base(correlationId) { }
    public dynamic StudentDto { get; set; }
}