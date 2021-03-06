namespace MajorVillage.Core.Services;

public class TypeIdentificationService : ITypeIdentificationService
{
    private readonly ITypeIdentificationRepository _typeIdentificationRepository;
    private readonly ILogger<TypeIdentificationService> _logger;

    public TypeIdentificationService(ITypeIdentificationRepository typeIdentificationRepository,
                                     ILogger<TypeIdentificationService> logger)
    {
        _typeIdentificationRepository = typeIdentificationRepository ?? throw new ArgumentNullException(nameof(typeIdentificationRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<GetAllTypeIdentificationResponse> GetAllTypeIdentifications(GetAllTypeIdentificationRequest request, CancellationToken cancellationToken)
    {
        GetAllTypeIdentificationResponse response = new(request.CorrelationId());
        response.TypeIdentifications = await _typeIdentificationRepository.GetAllIdentificationType(cancellationToken);
        return response;
    }
}