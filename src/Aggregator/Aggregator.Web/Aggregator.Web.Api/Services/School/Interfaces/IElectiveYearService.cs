namespace Aggregator.Web.Api.Interfaces;

public interface IElectiveYearService
{
    ValueTask<CreateElectiveYearResponse> CreateElectiveYearAsync(CreateElectiveYearRequest request, CallOptions callOptions);
    ValueTask<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CallOptions callOptions);
    ValueTask<GetAllElectivesYearsResponse> GetAllElectiveYearsAsync(GetAllElectivesYearsRequest request, CallOptions callOptions);
    ValueTask<GetElectiveYearByIdResponse> GetElectiveYearByIdAsync(GetElectiveYearByIdRequest request, CallOptions callOptions);
    ValueTask<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElectiveYearRequest request, CallOptions callOptions);
}