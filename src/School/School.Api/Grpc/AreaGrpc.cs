namespace School.Api.Grpc;

public class AreaGrpc : GrpcSchool.AreaService.AreaServiceBase
{
	private readonly ILoggerApplicationService<AreaGrpc> _logger;
	private readonly IAreaService _service;

    public AreaGrpc(ILoggerApplicationService<AreaGrpc> logger, IAreaService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreateAreaResponse> CreateArea(CreateAreaRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Grpc communication receive create area");
        return await _service.CreateAreaAsync(request, context.CancellationToken);
    }

    public override async Task<UpdateAreaResponse> UpdateArea(UpdateAreaRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Grpc communication receive update area");
        return await _service.UpdateAreaAsync(request, context.CancellationToken);
    }

    public override async Task<DeleteAreaResponse> DeleteArea(DeleteAreaRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Grpc communication receive delete area");
        return await _service.DeleteAreaAsync(request, context.CancellationToken);
    }

    public override async Task<GetAreaByIdResponse> GetAreaById(GetAreaByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Grpc communication receive get by id area");
        return await _service.GetAreaByIdAsync(request, context.CancellationToken);
    }

    public override async Task<GetAllAreasResponse> GetAllAreas(GetAllAreasRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Grpc communication receive get all areas");
        return await _service.GetAllAreasAsync(request, context.CancellationToken);
    }
}