namespace MajorVillage.Core.Interfaces;

public interface ICourseService
{
    Task<CreateCourseResponse> CreateCourse(CreateCourseRequest request, CancellationToken cancellationToken);
    Task<DeleteCourseResponse> DeleteCourse(DeleteCourseRequest request, CancellationToken cancellationToken);
    Task<GetAllCoursesResponse> GetAllCourses(GetAllCoursesRequest request, CancellationToken cancellationToken);
    Task<GetCourseByIdResponse> GetCourseById(GetCourseByIdRequest request, CancellationToken cancellationToken);
    Task<UpdateCourseResponse> UpdateCourse(UpdateCourseRequest request, CancellationToken cancellationToken);
}