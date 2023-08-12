namespace School.Api.Grpc;

public class CourseGrpc :GrpcSchool.CourseService.CourseServiceBase
{
    private readonly ILoggerApplicationService<CourseGrpc> _logger;
    private readonly ICourseService _service;

    public CourseGrpc(ILoggerApplicationService<CourseGrpc> logger, ICourseService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreateCourseResponse> CreateCourse(CreateCourseRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create course");
        return await _service.CreateCourseAsync(request, context.CancellationToken);
    }

    public override async Task<UpdateCourseResponse> UpdateCourse(UpdateCourseRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create course");
        return await _service.UpdateCourseAsync(request, context.CancellationToken);
    }

    public override async Task<DeleteCourseResponse> DeleteCourse(DeleteCourseRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create course");
        return await _service.DeleteCourseAsync(request, context.CancellationToken);
    }

    public override async Task<GetCourseByIdResponse> GetCourseById(GetCourseByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create course");
        return await _service.GetCourseByIdAsync(request, context.CancellationToken);
    }

    public override async Task<GetAllCoursesResponse> GetAllCourses(GetAllCoursesRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create course");
        return await _service.GetAllCoursesAsync(request, context.CancellationToken);
    }
}

