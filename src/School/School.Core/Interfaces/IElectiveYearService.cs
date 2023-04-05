namespace School.Core.Services;

public interface IElectiveYearService
{
    ValueTask<CreateElectiveYearResponse> CreateElectiveYearAsync(CreateElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllElectiveYearResponse> GetAllElectiveYearsAsync(GetAllElectiveYearRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElctiveYearRequest request, CancellationToken cancellationToken);
}