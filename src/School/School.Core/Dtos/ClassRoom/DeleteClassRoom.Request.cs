namespace School.Core.Dtos;

public record DeleteClassRoomRequest: BaseRequest
{
    public Guid Id { get; set; }
}

