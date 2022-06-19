namespace MajorVillage.Core.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILogger<CourseService> _logger;

    public CourseService(ICourseRepository courseRepository,
                         ILogger<CourseService> logger)
    {
        _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateCourseResponse> CreateCourse(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        CreateCourseResponse response = new(request.CorrelationId());
        _logger.LogInformation($"CreateCourse correlationdata {response.CorrelationId()}");
        response.Id = await _courseRepository.CreateCourseAsync(request.Course, cancellationToken);
        return response;
    }

    public async Task<UpdateCourseResponse> UpdateCourse(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        UpdateCourseResponse response = new(request.CorrelationId());
        _logger.LogInformation($"UpdateCourseRequest correlationdata {response.CorrelationId()}");
        response.CourseUpdated = await _courseRepository.UpdateCourseAsync(request.Course, cancellationToken);
        return response;
    }

    public async Task<GetAllCoursesResponse> GetAllCourses(GetAllCoursesRequest request, CancellationToken cancellationToken)
    {
        GetAllCoursesResponse response = new(request.CorrelationId());
        _logger.LogInformation($"GetAllCourses request relation ${response.CorrelationId()}");
        response.Courses = await _courseRepository.GetAllCoursesAsync(cancellationToken);
        return response;
    }

    public async Task<GetCourseByIdResponse> GetCourseById(GetCourseByIdRequest request, CancellationToken cancellationToken)
    {
        GetCourseByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request GetCourseById correlationId {response.CorrelationId()}");
        response.Course = await _courseRepository.GetCourseByIdAsync(request.Id, cancellationToken);
        return response;
    }

    public async Task<DeleteCourseResponse> DeleteCourse(DeleteCourseRequest request, CancellationToken cancellationToken)
    {
        DeleteCourseResponse response = new(request.CorrelationId());
        _logger.LogInformation($"DeleteCourse request information {response.CorrelationId()}");
        response.CourseDelete = await _courseRepository.DeleteCourseAsync(request.Course, cancellationToken);
        return response;
    }
}