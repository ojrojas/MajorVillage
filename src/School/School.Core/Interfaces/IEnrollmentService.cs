namespace School.Core.Interfaces;

public interface IEnrollmentService
{
    ValueTask<CreateEnrollmentResponse> CreateEnrollmentAsync(CreateEnrollmentRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteEnrollmentResponse> DeleteEnrollmentAsync(DeleteEnrollmentRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsAsync(GetAllEnrollmentsRequest request, CancellationToken cancellationToken);
    ValueTask<GetEnrollmentByIdResponse> GetEnrollmentByIdAsync(GetEnrollmentByIdRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsByElectiveYearAsync(GetAllEnrollmentsByElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateEnrollmentResponse> UpdateEnrollmentAsync(UpdateEnrollmentRequest request, CancellationToken cancellationToken);
}