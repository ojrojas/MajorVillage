namespace Aggregator.Web.Api.Interfaces;

public interface IPeriodService
{
    ValueTask<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request, CallOptions callOptions);
    ValueTask<DeletePeriodResponse> DeletePeriodAsync(DeletePeriodRequest request, CallOptions callOptions);
    ValueTask<GetAllPeriodsResponse> GetAllPeriodsAsync(GetAllPeriodsRequest request, CallOptions callOptions);
    ValueTask<GetPeriodByIdResponse> GetPeriodByIdAsync(GetPeriodByIdRequest request, CallOptions callOptions);
    ValueTask<UpdatePeriodResponse> UpdatePeriodAsync(UpdatePeriodRequest request, CallOptions callOptions);
}