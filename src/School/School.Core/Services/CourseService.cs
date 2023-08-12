namespace School.Core.Services;

public class CourseService : ICourseService
{
    private readonly ILoggerApplicationService<CourseService> _logger;
    private readonly CourseRepository _repository;
    private readonly IMapper _mapper;

    public CourseService(ILoggerApplicationService<CourseService> logger, CourseRepository repository, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request, CancellationToken cancellationToken)
    {
        CreateCourseResponse response = new();
        _logger.LogInformation(request.Correlationid, "Create course request");
        response.Coursecreated = _mapper.Map<GrpcSchool.Course>(await _repository.CreateAsync(_mapper.Map<Course>(request.Course), cancellationToken));
        _logger.LogInformation($"Create course entity: {JsonSerializer.Serialize(request.Course)}");
        return response;
    }

    public async ValueTask<UpdateCourseResponse> UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        UpdateCourseResponse response = new();
        _logger.LogInformation(request.Correlationid, "Update course request");
        response.Courseupdated = _mapper.Map<GrpcSchool.Course>(await _repository.UpdateAsync(_mapper.Map<Course>(request.Course), cancellationToken));
        _logger.LogInformation($"Update course, entity: {JsonSerializer.Serialize(request.Course)}");
        return response;
    }

    public async ValueTask<DeleteCourseResponse> DeleteCourseAsync(DeleteCourseRequest request, CancellationToken cancellationToken)
    {
        DeleteCourseResponse response = new();
        _logger.LogInformation(request.Correlationid, "Delete course request");
        var entity = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        _logger.LogInformation($"Delete course, entity: {JsonSerializer.Serialize(request.Id)}");
        response.Iscoursedeleted = await _repository.DeleteAsync(entity, cancellationToken) is not null;
        return response;
    }
    public async ValueTask<GetCourseByIdResponse> GetCourseByIdAsync(GetCourseByIdRequest request, CancellationToken cancellationToken)
    {
        GetCourseByIdResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get course by id request");
        response.Course = _mapper.Map<GrpcSchool.Course>(await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Get course by id, entity: {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async ValueTask<GetAllCoursesResponse> GetAllCoursesAsync(GetAllCoursesRequest request, CancellationToken cancellationToken)
    {
        GetAllCoursesResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        response.Courses.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<Course, GrpcSchool.Course>(_mapper));
        _logger.LogInformation($"Get all courses request");
        return response;
    }

    public async ValueTask<GetAllCoursesResponse> GetAllCoursesByElectiveYearAsync(GetAllCoursesByElectiveYearRequest request, CancellationToken cancellationToken)
    {
        GetAllCoursesResponse response = new();
        var specificationByElectiveYearId = new CourseSpecification(Guid.Parse(request.Electiveyearid));
        response.Courses.AddRange((await _repository.ListAsync(specificationByElectiveYearId, cancellationToken)).ToRepeatedTypeAsync<Course, GrpcSchool.Course>(_mapper));
        _logger.LogInformation($"Get all courses by elective year, elective year: {JsonSerializer.Serialize(request.Electiveyearid)}");
        return response;
    }
}