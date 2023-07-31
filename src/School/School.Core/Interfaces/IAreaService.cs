namespace School.Core.Interfaces;

public interface IAreaService
{
    ValueTask<CreateAreaResponse> CreateAreaAsync(CreateAreaRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteAreaResponse> DeleteAreaAsync(DeleteAreaRequest request, CancellationToken cancellationToken);
    ValueTask<GetAllAreasResponse> GetAllAreasAsync(GetAllAreasRequest request, CancellationToken cancellationToken);
    ValueTask<GetAreaByIdResponse> GetAreaByIdAsync(GetAreaByIdRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateAreaResponse> UpdateAreaAsync(UpdateAreaRequest request, CancellationToken cancellationToken);
}