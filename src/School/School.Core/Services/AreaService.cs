namespace School.Core.Services;

public class AreaService : IAreaService
{
    private readonly AreaRepository _repository;
    private readonly ILoggerApplicationService<AreaService> _logger;
    private readonly IMapper _mapper;

    public AreaService(AreaRepository repository, ILoggerApplicationService<AreaService> logger, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async ValueTask<CreateAreaResponse> CreateAreaAsync(CreateAreaRequest request, CancellationToken cancellationToken)
    {
        try
        {
            CreateAreaResponse response = new();
            _logger.LogInformation(request.Correlationid, "Create area request");
            response.Areacreated = _mapper.Map<GrpcSchool.Area>(await _repository.CreateAsync(_mapper.Map<Area>(request.Area), cancellationToken));
            _logger.LogInformation($"Created record params {JsonSerializer.Serialize(request.Area)}");

            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async ValueTask<UpdateAreaResponse> UpdateAreaAsync(UpdateAreaRequest request, CancellationToken cancellationToken)
    {
        UpdateAreaResponse response = new();
        _logger.LogInformation(request.Correlationid, "Update area request");
        response.Areaupdated = _mapper.Map<GrpcSchool.Area>(await _repository.UpdateAsync(_mapper.Map<Area>(request.Area), cancellationToken));
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Area)}");

        return response;
    }

    public async ValueTask<DeleteAreaResponse> DeleteAreaAsync(DeleteAreaRequest request, CancellationToken cancellationToken)
    {
        DeleteAreaResponse response = new();
        _logger.LogInformation(request.Correlationid, "Delete area request");
        var areaToDelete = await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        response.Isdeletedarea = await _repository.DeleteAsync(areaToDelete, cancellationToken) is not null;
        _logger.LogInformation($"Delete record params {request.Id}");

        return response;
    }

    public async ValueTask<GetAreaByIdResponse> GetAreaByIdAsync(GetAreaByIdRequest request, CancellationToken cancellationToken)
    {
        GetAreaByIdResponse response = new GetAreaByIdResponse();
        _logger.LogInformation(request.Correlationid, "Get area by id request");
        response.Area = _mapper.Map<GrpcSchool.Area>(await _repository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken));
        _logger.LogInformation($"Get by id area params {request.Id}");

        return response;
    }

    public async ValueTask<GetAllAreasResponse> GetAllAreasAsync(GetAllAreasRequest request, CancellationToken cancellationToken)
    {
        GetAllAreasResponse response = new();
        _logger.LogInformation(request.Correlationid, "Get all areas request");
        response.Areas.AddRange((await _repository.ListAsync(cancellationToken)).ToRepeatedTypeAsync<Area, GrpcSchool.Area>(_mapper));
        _logger.LogInformation($"Get all areas response count: {response.Areas.Count()}");

        return response;
    }
}