namespace MajorVillage.Core.Dtos;

public class ListUserResponse : BaseResponse
{
    public ListUserResponse(){}
    public ListUserResponse(Guid correlationId) : base(correlationId) { }
    public IEnumerable<User> ListUsers { get; set; }
}