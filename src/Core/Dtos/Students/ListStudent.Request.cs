namespace MajorVillage.Core.Dtos;

public class ListStudentRequest : BaseRequest
{
    public IPredicate predicate { get; set; }
}