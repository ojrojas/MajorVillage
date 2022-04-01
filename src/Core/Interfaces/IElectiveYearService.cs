namespace MajorVillage.Core.Interfaces;

public interface IElectiveYearService
{
    Task<CreateElectiveYearResponse> CreateElectiveYear(CreateElectiveYearRequest request, CancellationToken cancellationToken);
    Task<GetElectiveYearByIdResponse> GetElectiveYearById(GetElectiveYearByIdRequest request, CancellationToken cancellationToken);
}