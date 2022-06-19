namespace MajorVillage.Core.Services;

public class ElectiveYearService : IElectiveYearService
{
    private readonly IElectiveYearRepository _electiveRepsoitory;
    private readonly ILogger<ElectiveYearService> _logger;

    public ElectiveYearService(IElectiveYearRepository electiveRepsoitory,
                               ILogger<ElectiveYearService> logger)
    {
        _electiveRepsoitory = electiveRepsoitory ?? throw new ArgumentNullException(nameof(electiveRepsoitory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateElectiveYearResponse> CreateElectiveYear(CreateElectiveYearRequest request, CancellationToken cancellationToken)
    {
        CreateElectiveYearResponse response = new(request.CorrelationId());
        response.Id = await _electiveRepsoitory.CreateElectiveYear(request.ElectiveYear, cancellationToken);
        return response;
    }

    public async Task<GetElectiveYearByIdResponse> GetElectiveYearById(GetElectiveYearByIdRequest request, CancellationToken cancellationToken)
    {
        GetElectiveYearByIdResponse response = new(request.CorrelationId());
        response.ElectiveYear = await _electiveRepsoitory.GetElectiveYearById(request.Id, cancellationToken);
        return response;
    }

    public async Task<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CancellationToken cancellationToken)
    {
        DeleteElectiveYearResponse response= new(request.CorrelationId());
        response.ElectiveYearDeleted =  await _electiveRepsoitory.DeleteElectiveYear(request.ElectiveYear, cancellationToken);
        return response;
    }

    public async Task<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElectiveYearRequest request, CancellationToken cancellationToken)
    {
        UpdateElectiveYearResponse response= new(request.CorrelationId());
        response.ElectiveYearUpdated =  await _electiveRepsoitory.UpdateElectiveYear(request.ElectiveYear, cancellationToken);
        return response;
    }
}