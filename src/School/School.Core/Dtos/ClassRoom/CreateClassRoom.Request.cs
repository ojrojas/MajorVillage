namespace School.Core.Dtos;

public record CreateClassRoomRequest: BaseRequest
{
    public ClassRoom ClassRoom { get; set; }
}

