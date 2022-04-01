namespace MajorVillage.Core.Dtos;

public class ListUserRequest : BaseRequest
{
    public IPredicate predicate { get; set; }
}