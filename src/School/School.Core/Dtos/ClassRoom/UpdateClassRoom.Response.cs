namespace School.Core.Dtos;

public record UpdateClassRoomResponse: BaseResponse
{
	public UpdateClassRoomResponse(Guid correlationId): base(correlationId)
	{
	}

	public ClassRoom ClassRoomUpdated { get; set; }
}