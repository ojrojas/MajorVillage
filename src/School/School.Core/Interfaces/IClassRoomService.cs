namespace School.Core.Interfaces;

public interface IClassRoomService
{
    ValueTask<CreateClassRoomResponse> CreateClassRoomAsync(CreateClassRoomRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteClassRoomResponse> DeleteClassRoomAsync(DeleteClassRoomRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllClassRoomsResponse> GetAllClassRoomsAsync(GetAllClassRoomsRequest request, CancellationToken cancellationToken);
    ValueTask<GetClassRoomByIdResponse> GetClassRoomByIdAsync(GetClassRoomByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateClassRoomResponse> UpdateClassRoomAsync(UpdateClassRoomRequest request, CancellationToken cancellationToken);
}