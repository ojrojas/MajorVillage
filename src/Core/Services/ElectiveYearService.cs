namespace MajorVillage.Core.Services;

public class ElectiveYearService : IElectiveYearService
{
    private readonly IElectiveYearRepository _electiveRepsoitory;
    private readonly ILogger<ElectiveYearService> _logger;

    public ElectiveYearService(IElectiveYearRepository electiveRepsoitory, ILogger<ElectiveYearService> logger)
    {
        _electiveRepsoitory = electiveRepsoitory ?? throw new ArgumentNullException(nameof(electiveRepsoitory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateElectiveYearResponse> CreateElectiveYear(CreateElectiveYearRequest request, CancellationToken cancellationToken)
    {
        CreateElectiveYearResponse response = new(request.CorrelationId());
        response.Id = await _electiveRepsoitory.CreateElectiveYear(request.ElectiveYearDto, cancellationToken);
        return response;
    }

    public async Task<GetElectiveYearByIdResponse> GetElectiveYearById(GetElectiveYearByIdRequest request, CancellationToken cancellationToken)
    {
        GetElectiveYearByIdResponse response = new(request.CorrelationId());
        response.ElectiveYearDto = await _electiveRepsoitory.GetElectiveYearById(request.Id, cancellationToken);
        return response;
    }
}