namespace MajorVillage.Core.Interfaces;


public class GetAllCoursesRequest: BaseRequest
{
    public IPredicate predicateDto { get; set; }
}