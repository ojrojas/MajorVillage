namespace School.Core.Interfaces;

public interface ICourseService
{
    ValueTask<CreateCourseResponse> CreateCourseAsync(CreateCourseRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteCourseResponse> DeleteCourseAsync(DeleteCourseRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllCoursesResponse> GetAllCoursesAsync(GetAllCoursesRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllCoursesResponse> GetAllCoursesByElectiveYearAsync(GetAllCoursesByElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateCourseResponse> UpdateCourseAsync(UpdateCourseRequest request, CancellationToken cancellationToken);
    ValueTask<GetCourseByIdResponse> GetCourseByIdAsync(GetCourseByIdRequest request, CancellationToken cancellationToken);
}