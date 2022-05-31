namespace MajorVillage.Core.Services;

public class PermissionManagerService : IPermissionManagerService
{
    private readonly ILogger<PermissionManagerService> _logger;
    private readonly IPermissionManagerRepository _repository;

    public PermissionManagerService(ILogger<PermissionManagerService> logger, IPermissionManagerRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<PermissionManagerResponse> GetPermission(PermissionManagerRequest request, CancellationToken cancellationToken)
    {
        PermissionManagerResponse response = new(request.CorrelationId());
        response.PermissionManager = await _repository.GetPermission(request.TypeUserId, cancellationToken);
        return response;
    }

    public async Task<PermissionManagerActionResponse> GetPermissionAction(PermissionManagerActionRequest request, CancellationToken cancellationToken)
    {
        PermissionManagerActionResponse response = new(request.CorrelationId());
        response.PermissionAction = await _repository.GetPermissionAction(request.TypeUserId, cancellationToken);
        return response;
    }
}