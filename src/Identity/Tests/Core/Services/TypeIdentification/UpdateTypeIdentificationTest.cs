using Microsoft.AspNetCore.Mvc;

namespace Tests.Core.Services;

public class UpdateTypeIdentificationTest
{
    private readonly Mock<IGenericRepository<TypeIdentification>> _repositoryMock;
    private readonly Mock<ILogger<TypeIdentificationService>> _loggerMock;
    private readonly Mock<ITypeIdentificationService> _typeIdentificationServiceMock;

    public UpdateTypeIdentificationTest()
    {
        _repositoryMock = new Mock<IGenericRepository<TypeIdentification>>();
        _loggerMock = new Mock<ILogger<TypeIdentificationService>>();
        _typeIdentificationServiceMock = new Mock<ITypeIdentificationService>();
    }

    [Fact]
    public async Task Update_TypeIdentification_Success()
    {
        //Arrange
        // repo
        TypeIdentification typeIdentificationFake = GetTypeIdentificationFake();
        // dtos
        UpdateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();
        UpdateTypeIdentificationResponse response = GetTypeIdentificaitonResponseFake(request);

        _repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<TypeIdentification>(), default))
            .Returns(Task.FromResult(typeIdentificationFake));

        _typeIdentificationServiceMock.Setup(service => service.UpdateTypeIdentificationAsync(It.IsAny<UpdateTypeIdentificationRequest>(), default))
            .Returns(Task.FromResult(response));

        //Act
        UpdateTypeIdentification endpoint = new(_typeIdentificationServiceMock.Object);
        var actionResult = endpoint.HandleAsync(request, default);

        Assert.NotNull((actionResult.Result as UpdateTypeIdentificationResponse).TypeIdentificationUpdated);

    }

    [Fact]
    public async Task Update_TypeIdentification_Fail()
    {
        //Arrange
        // repo
        TypeIdentification typeIdentificationFake = GetTypeIdentificationFake();
        // dtos
        UpdateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();
        UpdateTypeIdentificationResponse response = GetTypeIdentificaitonResponseFake(request);

        _repositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<TypeIdentification>(), default))
            .Returns(Task.FromResult(typeIdentificationFake));

        _typeIdentificationServiceMock.Setup(service => service.UpdateTypeIdentificationAsync(It.IsAny<UpdateTypeIdentificationRequest>(), default))
            .Returns(Task.FromResult(new UpdateTypeIdentificationResponse(request.CorrelationId()) { TypeIdentificationUpdated = default }));

        //Act
        UpdateTypeIdentification endpoint = new(_typeIdentificationServiceMock.Object);
        var actionResult = endpoint.HandleAsync(default, default);

        Assert.Null((actionResult.Result as UpdateTypeIdentificationResponse).TypeIdentificationUpdated);

    }

    private UpdateTypeIdentificationResponse GetTypeIdentificaitonResponseFake(UpdateTypeIdentificationRequest request)
    {
        return new UpdateTypeIdentificationResponse(request.CorrelationId()) { TypeIdentificationUpdated = GetTypeIdentificationFake() };
    }

    private UpdateTypeIdentificationRequest GetTypeIdentificationRequestFake()
    {
        return new UpdateTypeIdentificationRequest { TypeIdentification = GetTypeIdentificationFake() };
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

