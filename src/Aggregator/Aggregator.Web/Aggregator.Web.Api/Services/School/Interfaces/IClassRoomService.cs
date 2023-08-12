namespace Aggregator.Web.Api.Interfaces;

public interface IClassRoomService
{
    ValueTask<CreateClassRoomResponse> CreateClassRoomAsync(CreateClassRoomRequest request, CallOptions callOptions);
    ValueTask<DeleteClassRoomResponse> DeleteClassRoomAsync(DeleteClassRoomRequest request, CallOptions callOptions);
    ValueTask<GetAllClassRoomsResponse> GetAllClassRoomAsync(GetAllClassRoomsRequest request, CallOptions callOptions);
    ValueTask<GetClassRoomByIdResponse> GetClassRoomByIdAsync(GetClassRoomByIdRequest request, CallOptions callOptions);
    ValueTask<UpdateClassRoomResponse> UpdateClassRoomAsync(UpdateClassRoomRequest request, CallOptions callOptions);
}