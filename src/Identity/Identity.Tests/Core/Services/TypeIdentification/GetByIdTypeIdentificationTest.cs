namespace Tests.Core.Services;

public class GetByIdTypeIdentificationTest: IClassFixture<IdentityApiFactory>
{
    private readonly HttpClient Client;
    public GetByIdTypeIdentificationTest(IdentityApiFactory factory)
    {
        Client = factory.CreateClient();
    }

    [Fact]
    public async Task GetById_TypeIdentification_Success()
    {
        //Arrange
        // dtos
        CreateTypeIdentificationRequest request = CreateTypeIdentification();

        //Act
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers. GetToken(Client));
        StringContent content = new(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response1 = await Client.PostAsync("/api/CreateTypeIdentification", content);
        response1.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"/api/GetTypeIdentificationById/{request.TypeIdentification.Id}");
        response.EnsureSuccessStatusCode();

        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetById_TypeIdentification_StatusCode_UnAthorize()
    {
        //Act
        var response = await Client.GetAsync($"/api/GetTypeIdentificationById/{Guid.NewGuid()}");
        Assert.True(response.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetById_TypeIdentification_Null_Exception()
    {
        //Act
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        var response = await Client.PostAsync("/api/GetByIdTypeIdentification", default);
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<GetTypeIdentificationByIdResponse>(stringResponse, Helpers._serializeSettings);
        Assert.Null(model);
    }

    private CreateTypeIdentificationRequest CreateTypeIdentification()
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