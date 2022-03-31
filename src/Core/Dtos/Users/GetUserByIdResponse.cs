namespace MajorVillage.Core.Dtos;

public class GetUserByIdResponse : BaseResponse
{
    public GetUserByIdResponse(){}
    public GetUserByIdResponse(Guid correlationId) : base(correlationId) { }
    public User UserDto { get; set; }
}