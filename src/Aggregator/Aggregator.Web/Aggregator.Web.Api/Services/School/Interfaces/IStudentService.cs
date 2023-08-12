namespace Aggregator.Web.Api.Interfaces;

public interface IStudentService
{
    ValueTask<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CallOptions callOptions);
    ValueTask<DeleteStudentResponse> DeleteStudentAsync(DeleteStudentRequest request, CallOptions callOptions);
    ValueTask<GetAllStudentsResponse> GetAllStudentsAsync(GetAllStudentsRequest request, CallOptions callOptions);
    ValueTask<GetStudentByIdResponse> GetStudentByIdAsync(GetStudentByIdRequest request, CallOptions callOptions);
    ValueTask<UpdateStudentResponse> UpdateStudentAsync(UpdateStudentRequest request, CallOptions callOptions);
}