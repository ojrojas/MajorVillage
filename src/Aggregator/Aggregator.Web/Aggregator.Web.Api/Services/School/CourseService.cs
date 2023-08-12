namespace Aggregator.Web.Api.Services;

public class CourseService : ICourseService
{
    private readonly ILoggerApplicationService<CourseService> _logger;
    private readonly GrpcSchool.CourseService.CourseServiceClient _client;

    public CourseService(ILoggerApplicationService<CourseService> logger, GrpcSchool.CourseService.CourseServiceClient client)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async ValueTask<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request create course");
        return await _client.CreateCourseAsync(request, callOptions);
    }

    public async ValueTask<UpdateCourseResponse> UpdateCourseAsync(UpdateCourseRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request update course");
        return await _client.UpdateCourseAsync(request, callOptions);
    }

    public async ValueTask<DeleteCourseResponse> DeleteCourseAsync(DeleteCourseRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request delete course");
        return await _client.DeleteCourseAsync(request, callOptions);
    }

    public async ValueTask<GetCourseByIdResponse> GetCourseByIdAsync(GetCourseByIdRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get course");
        return await _client.GetCourseByIdAsync(request, callOptions);
    }

    public async ValueTask<GetAllCoursesResponse> GetAllCoursesAsync(GetAllCoursesRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all courses");
        return await _client.GetAllCoursesAsync(request, callOptions);
    }

    public async ValueTask<GetAllCoursesResponse> GetAllCoursesByElectiveYearAsync(GetAllCoursesByElectiveYearRequest request, CallOptions callOptions)
    {
        _logger.LogInformation("Grpc request get all courses by elective year");
        return await _client.GetAllCoursesByElectiveYearAsync(request, callOptions);
    }
}