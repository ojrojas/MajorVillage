﻿using Microsoft.AspNetCore.Mvc;

namespace Tests.Core.Services;

public class UpdateTypeIdentificationTest
{
    private readonly IGenericRepository<TypeIdentification> _repository;
    private readonly ILogger<TypeIdentificationService> _logger;
    private readonly ITypeIdentificationService _typeIdentificationService;

    private readonly IdentityDbContext identityDbContext;
    private readonly DbContextOptions<IdentityDbContext> options;
    private const string isPayloadUpdate = "ISUPDATE";

    public UpdateTypeIdentificationTest()
    {
        var logger = LoggerFactory.Create(factory => factory.AddConsole());
        options = new DbContextOptionsBuilder<IdentityDbContext>().UseInMemoryDatabase(databaseName: "in-memory").Options;
        identityDbContext = new IdentityDbContext(options);
        _repository = new GenericRepository<TypeIdentification>(logger.CreateLogger<GenericRepository<TypeIdentification>>(), identityDbContext);
        _typeIdentificationService = new TypeIdentificationService(_repository, logger.CreateLogger<TypeIdentificationService>());

    }

    [Fact]
    public async Task Update_TypeIdentification_Success()
    {
        //Arrange
        var update = Task.Run(() => CreatePayloadData()).GetAwaiter();
        update.GetResult();

        //Act 1 Get from db
        GetAllTypeIdentification endpointget = new(_typeIdentificationService);
        var actionGet = endpointget.HandleAsync(default);

        var record = actionGet.Result.TypeIdentifications.FirstOrDefault();

        record.Name = isPayloadUpdate;

        //Act 2 update record
        UpdateTypeIdentification endpoint = new(_typeIdentificationService);
        var actionResult = endpoint.HandleAsync(new UpdateTypeIdentificationRequest { TypeIdentification= record }, default);

        Assert.True((actionResult.Result as UpdateTypeIdentificationResponse).TypeIdentificationUpdated.Name.Equals(isPayloadUpdate));

    }

    [Fact]
    public async Task Update_TypeIdentification_Fail()
    {
        //Arrange
        //Act
        UpdateTypeIdentification endpoint = new(_typeIdentificationService);
        var actionResult = endpoint.HandleAsync(default, default);

        Assert.ThrowsAsync(typeof(InvalidOperationException), () => actionResult);

    }

    private async Task CreatePayloadData()
    {
        await _repository.CreateAsync(GetTypeIdentificationFake(), default);
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
