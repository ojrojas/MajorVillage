namespace School.Core.Dtos;

public record GetAllClassRoomsResponse: BaseResponse
{
	public GetAllClassRoomsResponse(Guid correlationId):base(correlationId)
	{
	}

	public IEnumerable<ClassRoom> ClassRooms { get; set; }
}

