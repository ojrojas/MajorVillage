namespace School.Core.Dtos;

public record GetClassRoomByIdRequest: BaseRequest
{
    public Guid Id { get; set; }
}

