namespace MajorVillage.Core.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly IDapperRepository<Course> _repository;
    private readonly ILogger<Course> _logger;

    public CourseRepository(IDapperRepository<Course> repository,
                            ILogger<Course> logger)
    {
        _repository = repository ?? throw new ArgumentException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Guid> CreateCourseAsync(Course course, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Create course params {JsonSerializer.Serialize(course)}");
        return await _repository.InsertAsync(course, cancellationToken);
    }

    public async Task<bool> UpdateCourseAsync(Course course, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Create course params {JsonSerializer.Serialize(course)}");
        return await _repository.UpdateAsync(course, cancellationToken);
    }

    public async Task<bool> DeleteCourseAsync(Course course, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Delete course params {JsonSerializer.Serialize(course)}");
        return await _repository.DeleteAsync(course, cancellationToken);
    }

    public async Task<Course> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get course by id params {id}");
        IPredicate predicate = Predicates.Field<Course>(c => c.Id, Operator.Eq, id);
        return await _repository.GetByIdAsync(predicate, cancellationToken);
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get all courses request");
        return await _repository.GetAllAsync(null, cancellationToken);
    }
}