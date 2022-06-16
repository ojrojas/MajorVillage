namespace MajorVillage.Core.Interfaces;

public interface ICourseRepository
{
    Task<Guid> CreateCourseAsync(Course course, CancellationToken cancellationToken);
    Task<bool> DeleteCourseAsync(Course course, CancellationToken cancellationToken);
    Task<IEnumerable<Course>> GetAllCoursesAsync(CancellationToken cancellationToken);
    Task<Course> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> UpdateCourseAsync(Course course, CancellationToken cancellationToken);
}