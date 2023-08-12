namespace Aggregator.Web.Api.Services;

public class ClassRoomService : IClassRoomService
{
    private readonly ILoggerApplicationService<AreaService> _logger;
    private readonly GrpcSchool.ClassRoomService.ClassRoomServiceClient _client;

    public ClassRoomService(ILoggerApplicationService<AreaService> logger, GrpcSchool.ClassRoomService.ClassRoomServiceClient client)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<CreateClassRoomResponse> CreateClassRoomAsync(CreateClassRoomRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create classroom");
        return await _client.CreateClassRoomAsync(request, callOptions);
    }

    public async ValueTask<UpdateClassRoomResponse> UpdateClassRoomAsync(UpdateClassRoomRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update classroom");
        return await _client.UpdateClassRoomAsync(request, callOptions);
    }

    public async ValueTask<DeleteClassRoomResponse> DeleteClassRoomAsync(DeleteClassRoomRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete classroom");
        return await _client.DeleteClassRoomAsync(request, callOptions);
    }

    public async ValueTask<GetClassRoomByIdResponse> GetClassRoomByIdAsync(GetClassRoomByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get classroom by id ");
        return await _client.GetClassRoomByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllClassRoomsResponse> GetAllClassRoomAsync(GetAllClassRoomsRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get classroom by id ");
        return await _client.GetAllClassRoomsAsync(request, callOptions);
    }
}

