namespace MajorVillage.Core.Dtos;

public class GetAllTypeIdentificationRequest: BaseRequest
{
    public IPredicate predicate {get;set;}
}