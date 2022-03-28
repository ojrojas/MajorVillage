namespace MajorVillage.Core.Services
{
    public interface IStudentService
    {
        Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request, CancellationToken cancellationToken);
        Task<DeleteStudentResponse> DeleteStudentAsync(DeleteStudentRequest request, CancellationToken cancellationToken);
        Task<GetStudentByIdResponse> GetStudentByIdAsync(GetStudentByIdRequest request, CancellationToken cancellationToken);
        Task<ListStudentResponse> ListStudentAsync(ListStudentRequest request, CancellationToken cancellationToken);
        Task<UpdateStudentResponse> UpdateStudentAsync(CreateStudentRequest request, CancellationToken cancellationToken);
    }
}