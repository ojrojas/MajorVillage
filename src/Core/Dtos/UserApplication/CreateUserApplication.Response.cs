namespace MajorVillage.Core.Dtos;

public class CreateUserApplicationResponse :BaseResponse
{
    public CreateUserApplicationResponse(Guid correlationId): base(correlationId){}

    public Guid Id {get;set;}
}