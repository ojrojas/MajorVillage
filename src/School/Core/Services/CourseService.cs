namespace Core.Services;

public class CourseService
{
    private readonly ILogger<CourseService> _logger;
    private readonly CourseRepository _repository;

    public CourseService(ILogger<CourseService> logger, CourseRepository repository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async ValueTask<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        CreateCourseResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Create course request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.Course)}");
        response.CourseCreated = await _repository.CreateAsync(request.Course, cancellationToken);
        return response;
    }

    public async ValueTask<UpdateCourseResponse> UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        UpdateCourseResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Update course request id: {response.CorrelationId}, entity: {JsonSerializer.Serialize(request.Course)}");
        response.CourseUpdated = await _repository.UpdateAsync(request.Course, cancellationToken);
        return response;
    }

    public async ValueTask<GetAllCoursesResponse> GetAllCousesAsync(GetAllCoursesRequest request, CancellationToken cancellationToken)
    {
        GetAllCoursesResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Get all courses request id: {response.CorrelationId}");
        response.Courses = await _repository.ListAsync(cancellationToken);
        return response;
    }

    public async ValueTask<GetAllCoursesByElectiveYearResponse> GetAllCousesByElectiveYearAsync(
        GetAllCoursesByElectiveYearRequest request, CancellationToken cancellationToken)
    {
        GetAllCoursesByElectiveYearResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Get all courses by elective year request id: {response.CorrelationId}, elective year: {JsonSerializer.Serialize(request.ElectiveYearId)}");
        var specificationByElectiveYearId = new CourseSpecification(request.ElectiveYearId);
        response.Courses = await _repository.ListAsync(specificationByElectiveYearId, cancellationToken);
        return response;
    }
}

