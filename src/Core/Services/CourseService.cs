namespace MajorVillage.Core.Services;

public class CourseService 
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILogger<CourseService> _logger;

    public CourseService(ICourseRepository courseRepository,
                         ILogger<CourseService> logger)
    {
        _courseRepository = courseRepository;
        _logger = logger;
    }

}