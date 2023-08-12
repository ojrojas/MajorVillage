namespace Aggregator.Web.Api.Interfaces;

public interface IEnrollmentService
{
    ValueTask<CreateEnrollmentResponse> CreateEnrollmentAsync(CreateEnrollmentRequest request, CallOptions callOptions);
    ValueTask<DeleteEnrollmentResponse> DeleteEnrollmentAsync(DeleteEnrollmentRequest request, CallOptions callOptions);
    ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsAsync(GetAllEnrollmentsRequest request, CallOptions callOptions);
    ValueTask<GetEnrollmentByIdResponse> GetEnrollmentByIdAsync(GetEnrollmentByIdRequest request, CallOptions callOptions);
    ValueTask<UpdateEnrollmentResponse> UpdateEnrollmentAsync(UpdateEnrollmentRequest request, CallOptions callOptions);
    ValueTask<GetAllEnrollmentsResponse> GetAllEnrollmentsByElectiveYearIdAsync(GetAllEnrollmentsByElectiveYearRequest request, CallOptions callOptions);

}