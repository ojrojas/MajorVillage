namespace School.Core.Services;

public interface ICourseService
{
    ValueTask<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteCourseResponse> DeleteCourseAsync(DeleteCourseRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllCoursesResponse> GetAllCoursesAsync(GetAllCoursesRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllCoursesByElectiveYearResponse> GetAllCoursesByElectiveYearAsync(GetAllCoursesByElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateCourseResponse> UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken);
}