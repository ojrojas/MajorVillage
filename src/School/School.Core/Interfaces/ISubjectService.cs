namespace School.Core.Interfaces;

public interface ISubjectService
{
    ValueTask<CreateSubjectResponse> CreateSubjectAsync(CreateSubjectRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteSubjectResponse> DeleteSubjectAsync(DeleteSubjectRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllSubjectsResponse> GetAllSubjectsAsync(GetAllSubjectsRequest request, CancellationToken cancellationToken);
    ValueTask<GetSubjectByIdResponse> GetSubjectByIdAsync(GetSubjectByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateSubjectResponse> UpdateSubjectAsync(UpdateSubjectRequest request, CancellationToken cancellationToken);
}