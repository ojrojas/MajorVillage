namespace Identity.Tests.Core.Services;

public class GetByIdTypeUserTest: IClassFixture<IdentityApiFactory>
{
	private readonly HttpClient Client;
	public GetByIdTypeUserTest(IdentityApiFactory factory)
	{
		Client = factory.CreateClient();
	}

	[Fact]
	public async Task GetById_Should_Success_Ok()
	{
		//arrange
		CreateTypeUserRequest request = GetCreateTypeUserRequest();
		Guid requestById = request.TypeUser.Id;
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateTypeUser", content);
        response.EnsureSuccessStatusCode();
          
        //act
        var response2 = await Client.GetAsync($"/api/GetTypeUserById/{requestById}");
        response2.EnsureSuccessStatusCode();
        //assert
        Assert.True(response2.StatusCode.Equals(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetById_Should_Null()
    {
        //arrange
        Guid requestById = Guid.NewGuid();

        //act
        var response = await Client.GetAsync($"/api/GetTypeUserById/{requestById}");
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<CreateTypeIdentificationResponse>(stringResponse, Helpers._serializeSettings);

        //assert
        Assert.Null(model);
    }

    [Fact]
    public async Task GetById_Should_UnAuthorize_Status_Code()
    {
        //arrange
        Guid requestById = Guid.NewGuid();
        //act
        var response = await Client.GetAsync($"/api/GetTypeUserById/{requestById}");

        //assert
        Assert.True(response.StatusCode.Equals(HttpStatusCode.Unauthorized));
    }

    private CreateTypeUserRequest GetCreateTypeUserRequest()
    {
        return new CreateTypeUserRequest
        {
            TypeUser = new TypeUser
            {
                Id = Guid.NewGuid(),
                Name = "Student"
            }
        };
    }
}

