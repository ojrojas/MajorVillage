namespace Tests.Core.Services;

public class CreateTypeIdentificationTest
{
	private readonly TypeIdentificationRepository _repository;
	private readonly ILogger<TypeIdentificationService> _logger;
	private readonly ITypeIdentificationService _typeIdentificationService;

	private readonly IdentityAppDbContext identityDbContext;
	private readonly DbContextOptions<IdentityAppDbContext> options;

	public CreateTypeIdentificationTest()
	{
		var logger = LoggerFactory.Create(factory => factory.AddConsole());
        options = new DbContextOptionsBuilder<IdentityAppDbContext>().UseInMemoryDatabase(databaseName: "in-memory").Options;
		identityDbContext = new IdentityAppDbContext(options);
		_repository = new TypeIdentificationRepository(
			logger.CreateLogger<GenericRepository<TypeIdentification>>(), identityDbContext);
		_typeIdentificationService = new TypeIdentificationService(_repository,logger.CreateLogger<TypeIdentificationService>());
	}

	[Fact]
	public async Task Create_TypeIdentification_Success()
	{
		//Arrange
		// dtos
		CreateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();

		//Act
		CreateTypeIdentification endpoint = new CreateTypeIdentification(_typeIdentificationService);
		var actionResult = endpoint.HandleAsync(request, default); 

		Assert.NotNull((actionResult.Result as CreateTypeIdentificationResponse).TypeIdentificationCreated);

	}

    [Fact]
    public async Task Create_TypeIdentification_Fail()
    {
        //Act
        CreateTypeIdentification endpoint = new CreateTypeIdentification(_typeIdentificationService);
        var actionResult = endpoint.HandleAsync(default, default);
		Assert.ThrowsAsync(typeof (InvalidOperationException),() => actionResult);

    }

    private CreateTypeIdentificationRequest GetTypeIdentificationRequestFake()
    {
		return new CreateTypeIdentificationRequest { TypeIdentification = GetTypeIdentificationFake() };
    }

    private TypeIdentification GetTypeIdentificationFake()
    {
		return new TypeIdentification
		{
			Id = Guid.NewGuid(),
			Name = "CCI",
			CreatedBy = Guid.NewGuid(),
			CreatedDate = DateTime.UtcNow,
			State = true
		};
    }
}

