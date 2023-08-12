namespace School.Core.Services;

public class ElectiveYearService : IElectiveYearService
{
    private readonly ILoggerApplicationService<ElectiveYearService> _logger;
    private readonly ElectiveYearRepository _repository;
    private readonly IMapper _mapper;

    public ElectiveYearService(ILoggerApplicationService<ElectiveYearService> logger, ElectiveYearRepository repository, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreateElectiveYearResponse> CreateElectiveYearAsync(CreateElectiveYearRequest request, CancellationToken cancellationToken)
    {
        CreateElectiveYearResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        response.Electiveyearcreated = _mapper.Map<GrpcSchool.ElectiveYear>(await _repository.CreateAsync(_mapper.Map<ElectiveYear>(request.Electiveyear), cancellationToken));
        _logger.LogInformation($"Create ElectiveYear request, entity: {JsonSerializer.Serialize(request.Electiveyear)}");
        return response;
    }

    public async ValueTask<UpdateElectiveYearResponse> UpdateElectiveYearAsync(UpdateElectiveYearRequest request, CancellationToken cancellationToken)
    {
        UpdateElectiveYearResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        response.Electiveyearupdated = _mapper.Map<GrpcSchool.ElectiveYear>(await _repository.UpdateAsync(_mapper.Map<ElectiveYear>(request.Electiveyear), cancellationToken));
        _logger.LogInformation($"Update ElectiveYear request, entity: {JsonSerializer.Serialize(request.Electiveyear)}");
        return response;
    }

    public async ValueTask<DeleteElectiveYearResponse> DeleteElectiveYearAsync(DeleteElectiveYearRequest request, CancellationToken cancellationToken)
    {
        DeleteElectiveYearResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        var entity = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        _logger.LogInformation($"Delete ElectiveYear request, entity: {JsonSerializer.Serialize(request.Id)}");
        response.Iselectiveyeardeleted = await _repository.DeleteAsync(entity, cancellationToken) is not null;
        return response;
    }

    public async ValueTask<GetElectiveYearByIdResponse> GetElectiveYearByIdAsync(GetElectiveYearByIdRequest request, CancellationToken cancellationToken)
    {
        GetElectiveYearByIdResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        response.Electiveyear =_mapper.Map<GrpcSchool.ElectiveYear>(await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Get electiveyear by id request, entity: {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async ValueTask<GetAllElectivesYearsResponse> GetAllElectiveYearsAsync(GetAllElectivesYearsRequest request, CancellationToken cancellationToken)
    {
        GetAllElectivesYearsResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all courses request");
        response.Electivesyears.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<ElectiveYear, GrpcSchool.ElectiveYear>(_mapper));
        _logger.LogInformation($"Get all ElectiveYears request");
        return response;
    }
}

