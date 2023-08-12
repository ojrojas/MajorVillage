namespace School.Core.Services;

public class ClassRoomService : IClassRoomService
{
    private readonly ClassRoomRepository _repository;
    private readonly ILoggerApplicationService<ClassRoomService> _logger;
    private readonly IMapper _mapper;

    public ClassRoomService(ClassRoomRepository repository, ILoggerApplicationService<ClassRoomService> logger, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreateClassRoomResponse> CreateClassRoomAsync(CreateClassRoomRequest request, CancellationToken cancellationToken)
    {
        CreateClassRoomResponse response = new();
        _logger.LogInformation(request.Correlationid, "Create ClassRoom request");
        response.Classroomcreated = _mapper.Map<GrpcSchool.ClassRoom>(await _repository.CreateAsync(_mapper.Map<ClassRoom>(request.Classroom), cancellationToken));
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Classroom)}");

        return response;
    }

    public async ValueTask<UpdateClassRoomResponse> UpdateClassRoomAsync(UpdateClassRoomRequest request, CancellationToken cancellationToken)
    {
        UpdateClassRoomResponse response = new();
        _logger.LogInformation(request.Correlationid, "Update ClassRoom request");
        response.Classroomupdated = _mapper.Map<GrpcSchool.ClassRoom>(await _repository.UpdateAsync(_mapper.Map<ClassRoom>(request.Classroom), cancellationToken));
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Classroom)}");
        return response;
    }

    public async ValueTask<DeleteClassRoomResponse> DeleteClassRoomAsync(DeleteClassRoomRequest request, CancellationToken cancellationToken)
    {
        DeleteClassRoomResponse response = new();
        _logger.LogInformation(request.Correlationid, "Delete ClassRoom request");
        var ClassRoomToDelete = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        response.Isclassroomdeleted = await _repository.DeleteAsync(ClassRoomToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetClassRoomByIdResponse> GetClassRoomByIdAsync(GetClassRoomByIdRequest request, CancellationToken cancellationToken)
    {
        GetClassRoomByIdResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get ClassRoom by id request");
        response.Classroom = _mapper.Map<GrpcSchool.ClassRoom>(await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Get by id ClassRoom params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllClassRoomsResponse> GetAllClassRoomsAsync(GetAllClassRoomsRequest request, CancellationToken cancellationToken)
    {
        GetAllClassRoomsResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all ClassRooms request");
        response.Classrooms.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<ClassRoom, GrpcSchool.ClassRoom>(_mapper));
        _logger.LogInformation($"Get all ClassRooms response count: {response.Classrooms.Count()}");

        return response;
    }
}

