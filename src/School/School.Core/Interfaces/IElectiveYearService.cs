namespace School.Core.Interfaces;
public interface IElectiveYearService
{
    ValueTask<CreateElectiveYearResponse> CreateElectiveYearAsync(CreateElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllElectivesYearsResponse> GetAllElectiveYearsAsync(GetAllElectivesYearsRequest request, CancellationToken cancellationToken);
    ValueTask<GetElectiveYearByIdResponse> GetElectiveYearByIdAsync(GetElectiveYearByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElectiveYearRequest request, CancellationToken cancellationToken);
}
