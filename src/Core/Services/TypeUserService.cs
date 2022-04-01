namespace MajorVillage.Core.Services;

public class TypeUserService : ITypeUserService
{
    private readonly ITypeUserRepository _typeUserRepository;
    private readonly ILogger<TypeUserService> _logger;

    public TypeUserService(ITypeUserRepository typeUserRepository, ILogger<TypeUserService> logger)
    {
        _typeUserRepository = typeUserRepository ?? throw new ArgumentNullException(nameof(typeUserRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<GetAllTypeUserResponse> GetAllTypeUsers(GetAllTypeUsersRequest request, CancellationToken  cancellationToken)
    {
        GetAllTypeUserResponse response = new(request.CorrelationId());
        response.TypeUsers = await _typeUserRepository.GetAllUserType(request.predicate, cancellationToken);
        return response;
    }
}