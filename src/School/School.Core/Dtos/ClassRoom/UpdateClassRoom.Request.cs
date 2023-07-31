using System;
namespace School.Core.Dtos;

public record UpdateClassRoomRequest: BaseRequest
{
    public ClassRoom ClassRoom { get; set; }
}

