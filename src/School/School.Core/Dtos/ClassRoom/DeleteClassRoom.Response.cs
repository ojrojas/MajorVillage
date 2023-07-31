namespace School.Core.Dtos;

public record DeleteClassRoomResponse: BaseResponse
{
	public DeleteClassRoomResponse(Guid correlationId): base(correlationId)
	{
	}

	public bool IsClassRoomDeleted { get; set; }
}