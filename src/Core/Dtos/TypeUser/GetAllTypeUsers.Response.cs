namespace MajorVillage.Core.Dtos;

public class GetAllTypeUserResponse: BaseResponse
{
    public GetAllTypeUserResponse(Guid correlationId) : base(correlationId)
    {
    }

    public IEnumerable<TypeUser> TypeUsers { get; set; }
}