namespace MajorVillage.Core.Interfaces;

public interface IEnrollmentRepository
{
    Task<Guid> CreateEnrollment(Enrollment enrollment, CancellationToken cancellationToken);
    Task<bool> DeleteEnrollment(Enrollment enrollment, CancellationToken cancellationToken);
    Task<Enrollment> GetEnrollmentById(Guid id, CancellationToken cancellationToken);
    Task<bool> UpdateEnrollment(Enrollment enrollment, CancellationToken cancellationToken);
}