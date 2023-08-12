namespace Aggregator.Web.Api.Interfaces;

public interface IAreaService
{
    ValueTask<CreateAreaResponse> CreateAreaAsync(CreateAreaRequest request, CallOptions callOptions);
    ValueTask<DeleteAreaResponse> DeleteAreaAsync(DeleteAreaRequest request, CallOptions callOptions);
    ValueTask<GetAllAreasResponse> GetAllAreasAsync(GetAllAreasRequest request, CallOptions callOptions);
    ValueTask<GetAreaByIdResponse> GetAreaByIdAsync(GetAreaByIdRequest request, CallOptions callOptions);
    ValueTask<UpdateAreaResponse> UpdateAreaAsync(UpdateAreaRequest request, CallOptions callOptions);
}