namespace Aggregator.Web.Api.Interfaces;

public interface ICourseService
{
    ValueTask<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request, CallOptions callOptions);
    ValueTask<DeleteCourseResponse> DeleteCourseAsync(DeleteCourseRequest request, CallOptions callOptions);
    ValueTask<GetAllCoursesResponse> GetAllCoursesAsync(GetAllCoursesRequest request, CallOptions callOptions);
    ValueTask<GetAllCoursesResponse> GetAllCoursesByElectiveYearAsync(GetAllCoursesByElectiveYearRequest request, CallOptions callOptions);
    ValueTask<GetCourseByIdResponse> GetCourseByIdAsync(GetCourseByIdRequest request, CallOptions callOptions);
    ValueTask<UpdateCourseResponse> UpdateCourseAsync(UpdateCourseRequest request, CallOptions callOptions);
}