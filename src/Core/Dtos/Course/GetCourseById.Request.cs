namespace MajorVillage.Core.Interfaces;


public class GetCourseByIdRequest: BaseRequest
{
    public Guid Id { get; set; }
}