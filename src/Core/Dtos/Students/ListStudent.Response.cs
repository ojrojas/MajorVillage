namespace MajorVillage.Core.Dtos;

public class ListStudentResponse : BaseResponse
{
    public ListStudentResponse(){}
    public ListStudentResponse(Guid correlationId) : base(correlationId) { }
    public IEnumerable<Student> ListStudentsDto { get; set; }
}