namespace Tests.Core.Services;

public class CreateTypeIdentificationTest : IClassFixture<IdentityApiFactory>
{
    private readonly HttpClient Client;
  
    
    public CreateTypeIdentificationTest(IdentityApiFactory factory)
    {
        Client = factory.CreateClient();
    }

    [Fact]
    public async Task Create_TypeIdentification_Success()
    {
        //Arrange
        // dtos
        CreateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();

        //Act
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        StringContent content = new(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateTypeIdentification", content);
        response.EnsureSuccessStatusCode();
      
        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
    }

    [Fact]
    public async Task Create_TypeIdentification_StatusCode_UnAthorize()
    {
        //Act
        var response = await Client.PostAsync("/api/CreateTypeIdentification", default);
        Assert.True(response.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Create_TypeIdentification_Null_Exception()
    {
        //Act
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        var response = await Client.PostAsync("/api/CreateTypeIdentification", default);
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<CreateTypeIdentificationResponse>(stringResponse, Helpers._serializeSettings);
        Assert.Null(model);
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

