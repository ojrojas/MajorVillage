namespace Core.Services;

public class AddressService : IAddressService
{
    /// <summary>
    /// Generic repository instance type of Address
    /// </summary>
    private readonly IGenericRepository<Address> _repository;
    /// <summary>
    /// Logger instance type of Address Service
    /// </summary>
    private readonly ILogger<AddressService> _logger;

    /// <summary>
    /// Constructor 
    /// </summary>
    /// <param name="repository">Repository instance Address</param>
    /// <param name="logger">Logger instance service</param>
    /// <exception cref="ArgumentNullException">Dependency null exception instances type repository and logger</exception>
    public AddressService(IGenericRepository<Address> repository, ILogger<AddressService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateAddressResponse> CreateAddressAsync(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        CreateAddressResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.AddressCreated = await _repository.CreateAsync(request.Address, cancellationToken);
        _logger.LogInformation($"Create record params {JsonSerializer.Serialize(request.Address)}");
        return response;
    }

    public async Task<DeleteAddressResponse> DeleteAddressAsync(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        DeleteAddressResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        var Address = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.AddressDeleted = await _repository.DeleteAsync(Address, cancellationToken);
        _logger.LogInformation($"Delete record params {JsonSerializer.Serialize(request.Id)}");
        return response;

    }

    public async Task<GetAllAddressResponse> GetAllAddressAsync(GetAllAddressRequest request, CancellationToken cancellationToken)
    {
        GetAllAddressResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.Addresss = await _repository.ListAsync(cancellationToken);
        _logger.LogInformation($"Get all records");
        return response;
    }

    public async Task<GetAddressByIdResponse> GetAddressByIdAsync(GetAddressByIdRequest request, CancellationToken cancellationToken)
    {
        GetAddressByIdResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.Address = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _logger.LogInformation($"Get record by id params {JsonSerializer.Serialize(request.Id)}");
        return response;
    }

    public async Task<UpdateAddressResponse> UpdateAddressAsync(UpdateAddressRequest request, CancellationToken cancellationToken)
    {
        UpdateAddressResponse response = new(request.CorrelationId());
        _logger.LogInformation($"Request correlationId: {response.CorrelationId()}");
        response.AddressUpdated = await _repository.UpdateAsync(request.Address, cancellationToken);
        _logger.LogInformation($"Update record params {JsonSerializer.Serialize(request.Address)}");
        return response;
    }
}

