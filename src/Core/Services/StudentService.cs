namespace MajorVillage.Core.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<StudentService> _logger;

    public StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    public async Task<GetStudentByIdResponse> GetStudentByIdAsync(GetStudentByIdRequest request, CancellationToken cancellationToken)
    {
        var response = new GetStudentByIdResponse(request.CorrelationId());
        _logger.LogInformation($"Get student by id, in request {request.CorrelationId()}");
        var predicate = Predicates.Field<Student>(s => s.Id, Operator.Eq, request.Id);
        response.StudentDto = await _studentRepository.GetStudentByIdAsync(predicate, cancellationToken);
        return response;
    }

    public async Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CancellationToken cancellationToken)
    {
        CreateStudentResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Create student, in request {request.CorrelationId()}");
        var result = await _studentRepository.CreateStudentAsync(request.StudentDto, cancellationToken);
        return response;
    }

    public async Task<UpdateStudentResponse> UpdateStudentAsync(CreateStudentRequest request, CancellationToken cancellationToken)
    {
        UpdateStudentResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Update student, in request {request.CorrelationId()}");
        response.Updated = await _studentRepository.UpdateStudentAsync(request.StudentDto, cancellationToken);
        return response;
    }

    public async Task<DeleteStudentResponse> DeleteStudentAsync(DeleteStudentRequest request, CancellationToken cancellationToken)
    {
        DeleteStudentResponse response = new(request.CorrelationId());
        var newRequest = await _studentRepository.GetStudentByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Delete student, in request {request.CorrelationId()}");
        response.Deleted = await _studentRepository.DeleteStudentAsync(newRequest, cancellationToken);
        return response;
    }

    public async Task<ListStudentResponse> ListStudentAsync(ListStudentRequest request, CancellationToken cancellationToken)
    {
        ListStudentResponse response = new(request.CorrelationId());
        request.predicate = null;
        _logger.LogInformation($"List students, in request {request.CorrelationId()}");
        response.ListStudentsDto = await _studentRepository.ListStudentAsync(request.predicate, cancellationToken);
        return response;
    }
}