namespace School.Core.Interfaces;

public interface IPeriodService
{
    ValueTask<CreatePeriodResponse> CreatePeriodAsync(CreatePeriodRequest request, CancellationToken cancellationToken);
    ValueTask<DeletePeriodResponse> DeletePeriodAsync(DeletePeriodRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllPeriodsResponse> GetAllPeriodsAsync(GetAllPeriodsRequest request, CancellationToken cancellationToken);
    ValueTask<GetPeriodByIdResponse> GetPeriodByIdAsync(GetPeriodByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdatePeriodResponse> UpdatePeriodAsync(UpdatePeriodRequest request, CancellationToken cancellationToken);
}