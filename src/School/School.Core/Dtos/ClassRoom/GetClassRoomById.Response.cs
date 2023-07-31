namespace School.Core.Dtos;

public record GetClassRoomByIdResponse: BaseResponse
{
	public GetClassRoomByIdResponse(Guid correlationId): base(correlationId)
	{
	}

	public ClassRoom ClassRoom { get; set; }
}

