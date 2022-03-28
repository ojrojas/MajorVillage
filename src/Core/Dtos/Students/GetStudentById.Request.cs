namespace MajorVillage.Core.Dtos;

public class GetStudentByIdRequest : BaseResponse
{
    public Guid Id { get; set; }
}