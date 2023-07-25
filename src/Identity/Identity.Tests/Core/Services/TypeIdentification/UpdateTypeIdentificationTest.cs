namespace Tests.Core.Services;

public class UpdateTypeIdentificationTest : IClassFixture<IdentityApiFactory>
{
    private readonly HttpClient Client;

    public UpdateTypeIdentificationTest(IdentityApiFactory factory)
    {
        Client = factory.CreateClient();
    }

    [Fact]
    public async Task Update_TypeIdentification_Success()
    {
        //Arrange
        // dtos
        CreateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();

        //Act
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        StringContent content = new(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateTypeIdentification", content);
        response.EnsureSuccessStatusCode();
        request.TypeIdentification.Name = "TIT";
        request.TypeIdentification.UpdatedDate = DateTime.Now;

        var response2 = await Client.PatchAsync("/api/UpdateTypeIdentification", content);
        Assert.True(response2.StatusCode.Equals(HttpStatusCode.OK));

    }

    [Fact]
    public async Task Update_TypeIdentification_StatusCode_UnAthorize()
    {
        //Act
        var response = await Client.PatchAsync("/api/UpdateTypeIdentification", default);
        Assert.True(response.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Update_TypeIdentification_Null_Exception()
    {
        //Act
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        var response = await Client.PatchAsync("/api/UpdateTypeIdentification", default);
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<UpdateTypeIdentificationResponse>(stringResponse, Helpers._serializeSettings);
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

