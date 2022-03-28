namespace MajorVillage.Core.Dtos;

public class GetStudentByIdResponse : BaseResponse
{
    public GetStudentByIdResponse(){}
    public GetStudentByIdResponse(Guid correlationId) : base(correlationId) { }
    public Student StudentDto { get; set; }
}