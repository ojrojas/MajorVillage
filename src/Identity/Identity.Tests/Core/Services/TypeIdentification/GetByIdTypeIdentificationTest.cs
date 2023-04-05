namespace Tests.Core.Services;

public class GetByIdTypeIdentificationTest
{
    private readonly TypeIdentificationRepository _repository;
    private readonly ILogger<TypeIdentificationService> _logger;
    private readonly ITypeIdentificationService _typeIdentificationService;

    private readonly IdentityDbContext identityDbContext;
    private readonly DbContextOptions<IdentityDbContext> options;
    private readonly Guid typeIdentificationById = Guid.NewGuid();

    public GetByIdTypeIdentificationTest()
    {
        var logger = LoggerFactory.Create(factory => factory.AddConsole());
        options = new DbContextOptionsBuilder<IdentityDbContext>().UseInMemoryDatabase(databaseName: "in-memory").Options;
        identityDbContext = new IdentityDbContext(options);
        _repository = new TypeIdentificationRepository(
             logger.CreateLogger<GenericRepository<TypeIdentification>>(), identityDbContext);
        _typeIdentificationService = new TypeIdentificationService(_repository, logger.CreateLogger<TypeIdentificationService>());
    }

    [Fact]
    public async Task GetById_TypeIdentification_Success()
    {
        //Arrange
        var update = Task.Run(() => CreatePayloadData()).GetAwaiter();
        update.GetResult();
        // dtos
        GetTypeIdentificationByIdRequest request = new() { Id = typeIdentificationById};

        //Act
        GetTypeIdentificationById endpoint = new GetTypeIdentificationById(_typeIdentificationService);
        var actionResult = endpoint.HandleAsync(request, default);

        Assert.True((actionResult.Result as GetTypeIdentificationByIdResponse).TypeIdentification.Id.Equals(typeIdentificationById));
    }

    [Fact]
    public async Task GetById_TypeIdentification_Fail()
    {
        //Act
        GetTypeIdentificationById endpoint = new GetTypeIdentificationById(_typeIdentificationService);
        var actionResult = endpoint.HandleAsync(default, default);

        Assert.ThrowsAsync(typeof(InvalidOperationException), () => actionResult);

    }

    private async Task CreatePayloadData()
    {
        await _repository.CreateAsync(GetTypeIdentificationFake(), default);
    }

    private TypeIdentification GetTypeIdentificationFake()
    {
        return new TypeIdentification
        {
            Id = typeIdentificationById,
            Name = "CCI",
            CreatedBy = Guid.NewGuid(),
            CreatedDate = DateTime.UtcNow,
            State = true
        };
    }
}

