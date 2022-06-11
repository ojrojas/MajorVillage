namespace MajorVillage.Core.Interfaces;

public interface IEnrollmentService
{
    Task<CreateEnrollmentResponse> CreateEnrollment(CreateEnrollmentRequest request, CancellationToken cancellationToken);
    Task<DeleteEnrollmentResponse> DeleteEnrollment(DeleteEnrollmentRequest request, CancellationToken cancellationToken);
    Task<GetByIdEnrollmentResponse> GetEnrollmentById(GetByIdEnrollmentRequest request, CancellationToken cancellationToken);
    Task<UpdateEnrollmentResponse> UpdateEnrollment(UpdateEnrollmentRequest request, CancellationToken cancellationToken);
}