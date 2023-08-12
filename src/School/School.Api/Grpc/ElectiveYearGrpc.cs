namespace School.Api.Grpc;

public class ElectiveYearGrpc: GrpcSchool.ElectiveYearService.ElectiveYearServiceBase
{
    private readonly ILoggerApplicationService<ElectiveYearGrpc> _logger;
    private readonly IElectiveYearService _service;

    public ElectiveYearGrpc(ILoggerApplicationService<ElectiveYearGrpc> logger, IElectiveYearService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public override async Task<CreateElectiveYearResponse> CreateElectiveYear(CreateElectiveYearRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive elective year");
        return await _service.CreateElectiveYearAsync(request, context.CancellationToken);
    }

    public override async Task<UpdateElectiveYearResponse> UpdateElectiveYear(UpdateElectiveYearRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create elective year");
        return await _service.UpdateElectiveYearAsync(request, context.CancellationToken);
    }

    public override async Task<DeleteElectiveYearResponse> DeleteElectiveYear(DeleteElectiveYearRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create elective year");
        return await _service.DeleteElectiveYearAsync(request, context.CancellationToken);
    }

    public override async Task<GetElectiveYearByIdResponse> GetElectiveYearById(GetElectiveYearByIdRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create elective year");
        return await _service.GetElectiveYearByIdAsync(request, context.CancellationToken);
    }

    public override async Task<GetAllElectivesYearsResponse> GetAllElectivesYears(GetAllElectivesYearsRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Gprc communication receive create elective year");
        return await _service.GetAllElectiveYearsAsync(request, context.CancellationToken);
    }
}

