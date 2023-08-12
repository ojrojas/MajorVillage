namespace School.Core.Services;

public class StudentService : IStudentService
{
    private readonly StudentRepository _repository;
    private readonly ILoggerApplicationService<StudentService> _logger;
    private readonly IMapper _mapper;

    public StudentService(StudentRepository repository, ILoggerApplicationService<StudentService> logger, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CancellationToken cancellationToken)
    {
        CreateStudentResponse response = new();
        _logger.LogInformation(request.Correlationid, "Create Student request");
        response.Studentcreated = _mapper.Map<GrpcSchool.Student>(await _repository.CreateAsync(_mapper.Map<Student>(request.Student), cancellationToken));
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Student)}");

        return response;
    }

    public async ValueTask<UpdateStudentResponse> UpdateStudentAsync(UpdateStudentRequest request, CancellationToken cancellationToken)
    {
        UpdateStudentResponse response = new();
        _logger.LogInformation(request.Correlationid, "Update Student request");
        response.Studentupdated = _mapper.Map<GrpcSchool.Student>(await _repository.UpdateAsync(_mapper.Map<Student>(request.Student), cancellationToken));
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Student)}");

        return response;
    }

    public async ValueTask<DeleteStudentResponse> DeleteStudentAsync(DeleteStudentRequest request, CancellationToken cancellationToken)
    {
        DeleteStudentResponse response = new();
        _logger.LogInformation(request.Correlationid, "Delete Student request");
        var StudentToDelete = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        response.Isstudentdeleted = await _repository.DeleteAsync(StudentToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetStudentByIdResponse> GetStudentByIdAsync(GetStudentByIdRequest request, CancellationToken cancellationToken)
    {
        GetStudentByIdResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get Student by id request");
        response.Student = _mapper.Map<GrpcSchool.Student>(await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Get by id Student params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllStudentsResponse> GetAllStudentsAsync(GetAllStudentsRequest request, CancellationToken cancellationToken)
    {
        GetAllStudentsResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all Students request");
        response.Students.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<Student, GrpcSchool.Student>(_mapper));
        _logger.LogInformation($"Get all Students response count: {response.Students.Count()}");

        return response;
    }
}