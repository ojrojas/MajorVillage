namespace MajorVillage.Core.Dtos;

public class GetUserByIdRequest : BaseResponse
{
    public Guid Id { get; set; }
}