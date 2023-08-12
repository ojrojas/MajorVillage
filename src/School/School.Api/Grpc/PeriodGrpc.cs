namespace School.Api.Grpc;

public class PeriodGrpc : GrpcSchool.PeriodService.PeriodServiceBase
{
    private readonly ILoggerApplicationService<PeriodGrpc> _logger;
    private readonly IPeriodService _service;

    public PeriodGrpc(ILoggerApplicationService<PeriodGrpc> logger, IPeriodService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override  async Task<CreatePeriodResponse> CreatePeriod(CreatePeriodRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create period");
        return await _service.CreatePeriodAsync(request, context.CancellationToken);
    }

    public override async Task<UpdatePeriodResponse> UpdatePeriod(UpdatePeriodRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive update period");
        return await _service.UpdatePeriodAsync(request, context.CancellationToken);
    }

    public override async Task<DeletePeriodResponse> DeletePeriod(DeletePeriodRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive delete period");
        return await _service.DeletePeriodAsync(request, context.CancellationToken);
    }

    public override async Task<GetPeriodByIdResponse> GetPeriodById(GetPeriodByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get period by id");
        return await _service.GetPeriodByIdAsync(request, context.CancellationToken);
    }

    public override async Task<GetAllPeriodsResponse> GetAllsPeriods(GetAllPeriodsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive get all period");
        return await _service.GetAllPeriodsAsync(request, context.CancellationToken);
    }
}

