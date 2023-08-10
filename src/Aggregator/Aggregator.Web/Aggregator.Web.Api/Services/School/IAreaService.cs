namespace Aggregator.Web.Api.Services;

public interface IAreaService
{
    ValueTask<CreateAreaResponse> CreateAreaAsync(CreateAreaRequest request, CancellationToken cancellationToken);
}