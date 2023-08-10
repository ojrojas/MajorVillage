using Grpc.Core;

namespace School.Api.Grpc;

public class AreaGrpc : GrpcSchool.AreaService.AreaServiceBase
{
	private readonly ILogger<AreaGrpc> _logger;
	private readonly IAreaService _service;

    public AreaGrpc(ILogger<AreaGrpc> logger, IAreaService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<GrpcSchool.CreateAreaResponse> CreateArea(GrpcSchool.CreateAreaRequest request, ServerCallContext context)
    {
        return await _service.CreateAreaAsync(request, context.CancellationToken);
    }

    public override Task<GrpcSchool.UpdateAreaResponse> UpdateArea(GrpcSchool.UpdateAreaRequest request, ServerCallContext context)
    {
        return base.UpdateArea(request, context);
    }

    public override Task<GrpcSchool.DeleteAreaResponse> DeleteArea(GrpcSchool.DeleteAreaRequest request, ServerCallContext context)
    {
        return base.DeleteArea(request, context);
    }

    public override Task<GrpcSchool.GetAreaByIdResponse> GetAreaById(GrpcSchool.GetAreaByIdRequest request, ServerCallContext context)
    {
        return base.GetAreaById(request, context);
    }

    public override Task<GrpcSchool.GetAllAreasResponse> GetAllAreas(GrpcSchool.GetAllAreasRequest request, ServerCallContext context)
    {
        return base.GetAllAreas(request, context);
    }
}