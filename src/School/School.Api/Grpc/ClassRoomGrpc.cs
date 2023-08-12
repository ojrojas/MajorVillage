namespace School.Api.Grpc;

public class ClassRoomGrpc : GrpcSchool.ClassRoomService.ClassRoomServiceBase
{
    private readonly ILoggerApplicationService<ClassRoomGrpc> _logger;
    private readonly IClassRoomService _service;

    public ClassRoomGrpc(ILoggerApplicationService<ClassRoomGrpc> logger, IClassRoomService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreateClassRoomResponse> CreateClassRoom(CreateClassRoomRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create classroom");
        return await _service.CreateClassRoomAsync(request, context.CancellationToken);
    }

    public override async Task<UpdateClassRoomResponse> UpdateClassRoom(UpdateClassRoomRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive update classroom");
        return await _service.UpdateClassRoomAsync(request, context.CancellationToken);

    }

    public override async Task<DeleteClassRoomResponse> DeleteClassRoom(DeleteClassRoomRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive delete classroom");
        return await _service.DeleteClassRoomAsync(request, context.CancellationToken);

    }

    public override async Task<GetClassRoomByIdResponse> GetClassRoomById(GetClassRoomByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get by id classroom");
        return await _service.GetClassRoomByIdAsync(request, context.CancellationToken);

    }

    public override async Task<GetAllClassRoomsResponse> GetAllClassRooms(GetAllClassRoomsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get all classrooms");
        return await _service.GetAllClassRoomsAsync(request, context.CancellationToken);

    }
}

