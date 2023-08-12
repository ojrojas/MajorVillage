namespace School.Api.Grpc;

public class StudentGrpc: GrpcSchool.StudentService.StudentServiceBase
{
    private readonly ILoggerApplicationService<StudentGrpc> _logger;
    private readonly IStudentService _service;

    public StudentGrpc(ILoggerApplicationService<StudentGrpc> logger, IStudentService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreateStudentResponse> CreateStudent(CreateStudentRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create student");
        return await _service.CreateStudentAsync(request, context.CancellationToken);
    }

    public override async Task<UpdateStudentResponse> UpdateStudent(UpdateStudentRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive update student");
        return await _service.UpdateStudentAsync(request, context.CancellationToken);
    }

    public override async Task<DeleteStudentResponse> DeleteStudent(DeleteStudentRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive delete student");
        return await _service.DeleteStudentAsync(request, context.CancellationToken);
    }

    public override async Task<GetStudentByIdResponse> GetStudentById(GetStudentByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get student by");
        return await _service.GetStudentByIdAsync(request, context.CancellationToken);
    }

    public override async Task<GetAllStudentsResponse> GetAllStudents(GetAllStudentsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive Get all student");
        return await _service.GetAllStudentsAsync(request, context.CancellationToken);
    }
}

