using Microsoft.AspNetCore.Mvc;

namespace Tests.Core.Services;

public class CreateTypeIdentificationTest
{
	private readonly Mock<IGenericRepository<TypeIdentification>> _repositoryMock;
	private readonly Mock<ILogger<TypeIdentificationService>> _loggerMock;
	private readonly Mock<ITypeIdentificationService> _typeIdentificationServiceMock;

	public CreateTypeIdentificationTest()
	{
		_repositoryMock = new Mock<IGenericRepository<TypeIdentification>>();
		_loggerMock = new Mock<ILogger<TypeIdentificationService>>();
		_typeIdentificationServiceMock = new Mock<ITypeIdentificationService>();
	}

	[Fact]
	public async Task Create_TypeIdentification_Success()
	{
		//Arrange
		// repo
		TypeIdentification typeIdentificationFake = GetTypeIdentificationFake();
		// dtos
		CreateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();
		CreateTypeIdentificationResponse response = GetTypeIdentificaitonResponseFake(request);

		_repositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<TypeIdentification>(), default))
			.Returns(Task.FromResult(typeIdentificationFake));

		_typeIdentificationServiceMock.Setup(service => service.CreateTypeIdentificationAsync(It.IsAny<CreateTypeIdentificationRequest>(), default))
			.Returns(Task.FromResult(response));

		//Act
		CreateTypeIdentification endpoint = new CreateTypeIdentification(_typeIdentificationServiceMock.Object);
		var actionResult = endpoint.HandleAsync(request, default);

		Assert.NotNull((actionResult.Result as CreateTypeIdentificationResponse).TypeIdentificationCreated);

	}

    [Fact]
    public async Task Create_TypeIdentification_Fail()
    {
        //Arrange
        // repo
        TypeIdentification typeIdentificationFake = GetTypeIdentificationFake();
        // dtos
        CreateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();
        CreateTypeIdentificationResponse response = GetTypeIdentificaitonResponseFake(request);

        _repositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<TypeIdentification>(), default))
            .Returns(Task.FromResult(typeIdentificationFake));

        _typeIdentificationServiceMock.Setup(service => service.CreateTypeIdentificationAsync(It.IsAny<CreateTypeIdentificationRequest>(), default))
            .Returns(Task.FromResult(new CreateTypeIdentificationResponse(request.CorrelationId()) { TypeIdentificationCreated = default }));

        //Act
        CreateTypeIdentification endpoint = new CreateTypeIdentification(_typeIdentificationServiceMock.Object);
        var actionResult = endpoint.HandleAsync(default, default);

        Assert.Null((actionResult.Result as CreateTypeIdentificationResponse).TypeIdentificationCreated);

    }

    private CreateTypeIdentificationResponse GetTypeIdentificaitonResponseFake(CreateTypeIdentificationRequest request)
    {
		return new CreateTypeIdentificationResponse(request.CorrelationId()) { TypeIdentificationCreated = GetTypeIdentificationFake() };
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

