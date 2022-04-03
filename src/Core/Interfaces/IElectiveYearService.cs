namespace MajorVillage.Core.Interfaces;

public interface IElectiveYearService
{
    Task<CreateElectiveYearResponse> CreateElectiveYear(CreateElectiveYearRequest request, CancellationToken cancellationToken);
    Task<GetElectiveYearByIdResponse> GetElectiveYearById(GetElectiveYearByIdRequest request, CancellationToken cancellationToken);
    Task<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CancellationToken cancellationToken);
    Task<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElectiveYearRequest request, CancellationToken cancellationToken);
}