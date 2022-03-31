namespace MajorVillage.Core.Dtos;

public class CreateUserResponse : BaseResponse
{
    public CreateUserResponse(Guid correlationId) : base(correlationId) { }
    public Guid CreatedUser { get; set; }
}