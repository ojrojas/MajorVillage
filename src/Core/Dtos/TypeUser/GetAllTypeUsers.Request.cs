namespace MajorVillage.Core.Dtos;

public class GetAllTypeUsersRequest: BaseRequest
{
    public IPredicate predicate { get; set; }
}