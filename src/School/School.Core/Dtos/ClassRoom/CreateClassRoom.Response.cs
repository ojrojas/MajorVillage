namespace School.Core.Dtos;

public record CreateClassRoomResponse: BaseResponse
{
	public CreateClassRoomResponse(Guid correlationId): base(correlationId)
	{
	}

	public ClassRoom ClassRoomCreated { get; set; }
}

