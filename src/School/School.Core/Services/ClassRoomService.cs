namespace School.Core.Services;

public class ClassRoomService : IClassRoomService
{
    private readonly ClassRoomRepository _repository;
    private readonly ILoggerApplicationService<ClassRoomService> _logger;

    public ClassRoomService(ClassRoomRepository repository, ILoggerApplicationService<ClassRoomService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateClassRoomResponse> CreateClassRoomAsync(CreateClassRoomRequest request, CancellationToken cancellationToken)
    {
        CreateClassRoomResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create ClassRoom request");
        response.ClassRoomCreated = await _repository.CreateAsync(request.ClassRoom, cancellationToken);
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.ClassRoom)}");

        return response;
    }

    public async ValueTask<UpdateClassRoomResponse> UpdateClassRoomAsync(UpdateClassRoomRequest request, CancellationToken cancellationToken)
    {
        UpdateClassRoomResponse response = new UpdateClassRoomResponse(request.CorrelationId());
        _logger.LogInformation(response, "Update ClassRoom request");
        response.ClassRoomUpdated = await _repository.UpdateAsync(request.ClassRoom, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.ClassRoom)}");

        return response;
    }

    public async ValueTask<DeleteClassRoomResponse> DeleteClassRoomAsync(DeleteClassRoomRequest request, CancellationToken cancellationToken)
    {
        DeleteClassRoomResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete ClassRoom request");
        var ClassRoomToDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.IsClassRoomDeleted = await _repository.DeleteAsync(ClassRoomToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetClassRoomByIdResponse> GetClassRoomByIdAsync(GetClassRoomByIdRequest request, CancellationToken cancellationToken)
    {
        GetClassRoomByIdResponse response = new GetClassRoomByIdResponse(request.CorrelationId());
        _logger.LogInformation(response, "Get ClassRoom by id request");
        response.ClassRoom = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get by id ClassRoom params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllClassRoomsResponse> GetAllClassRoomsAsync(GetAllClassRoomsRequest request, CancellationToken cancellationToken)
    {
        GetAllClassRoomsResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all ClassRooms request");
        response.ClassRooms = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all ClassRooms response count: {response.ClassRooms.Count()}");

        return response;
    }
}

