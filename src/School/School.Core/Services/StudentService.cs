namespace School.Core.Services;

public class StudentService : IStudentService
{
    private readonly StudentRepository _repository;
    private readonly ILoggerApplicationService<StudentService> _logger;

    public StudentService(StudentRepository repository, ILoggerApplicationService<StudentService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CancellationToken cancellationToken)
    {
        CreateStudentResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Create Student request");
        response.StudentCreated = await _repository.CreateAsync(request.Student, cancellationToken);
        _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Student)}");

        return response;
    }

    public async ValueTask<UpdateStudentResponse> UpdateStudentAsync(UpdateStudentRequest request, CancellationToken cancellationToken)
    {
        UpdateStudentResponse response = new UpdateStudentResponse(request.CorrelationId());
        _logger.LogInformation(response, "Update Student request");
        response.StudentUpdated = await _repository.UpdateAsync(request.Student, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Student)}");

        return response;
    }

    public async ValueTask<DeleteStudentResponse> DeleteStudentAsync(DeleteStudentRequest request, CancellationToken cancellationToken)
    {
        DeleteStudentResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Delete Student request");
        var StudentToDelete = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.IsStudentDeleted = await _repository.DeleteAsync(StudentToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetStudentByIdResponse> GetStudentByIdAsync(GetStudentByIdRequest request, CancellationToken cancellationToken)
    {
        GetStudentByIdResponse response = new GetStudentByIdResponse(request.CorrelationId());
        _logger.LogInformation(response, "Get Student by id request");
        response.Student = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get by id Student params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllStudentsResponse> GetAllStudentsAsync(GetAllStudentsRequest request, CancellationToken cancellationToken)
    {
        GetAllStudentsResponse response = new(request.CorrelationId());
        _logger.LogInformation(response, "Get all Students request");
        response.Students = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all Students response count: {response.Students.Count()}");

        return response;
    }
}

