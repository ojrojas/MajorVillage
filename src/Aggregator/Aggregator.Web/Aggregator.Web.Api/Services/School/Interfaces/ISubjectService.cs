namespace Aggregator.Web.Api.Interfaces;

public interface ISubjectService
{
    ValueTask<CreateSubjectResponse> CreateSubjectAsync(CreateSubjectRequest request, CallOptions callOptions);
    ValueTask<DeleteSubjectResponse> DeleteSubjectAsync(DeleteSubjectRequest request, CallOptions callOptions);
    ValueTask<GetAllSubjectsResponse> GetAllSubjectsAsync(GetAllSubjectsRequest request, CallOptions callOptions);
    ValueTask<GetSubjectByIdResponse> GetSubjectByIdAsync(GetSubjectByIdRequest request, CallOptions callOptions);
    ValueTask<UpdateSubjectResponse> UpdateSubjectAsync(UpdateSubjectRequest request, CallOptions callOptions);
}