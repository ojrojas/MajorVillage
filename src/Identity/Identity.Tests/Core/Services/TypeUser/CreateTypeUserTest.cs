namespace Identity.Tests.Core.Services;

public class CreateTypeUserTest : IClassFixture<IdentityApiFactory>
{
	private readonly HttpClient Client;
	public CreateTypeUserTest(IdentityApiFactory factory)
	{
		Client = factory.CreateClient();
	}

	[Fact]
	public async Task Create_TypeUser_Should_HttpStatus_OK()
	{
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        CreateTypeUserRequest request = GetCreateTypeUserRequest();
		StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
		var response = await Client.PostAsync("/api/CreateTypeUser", content);
		response.EnsureSuccessStatusCode();

		Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
	}

	[Fact]
    public async Task Create_TypeUser_Should_Null()
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        var response = await Client.PostAsync("/api/CreateTypeUser", default);
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<CreateTypeIdentificationResponse>(stringResponse, Helpers._serializeSettings);

        Assert.Null(model);
    }

	[Fact]
    public async Task Create_TypeUser_Should_UnAuthorize()
    {
        var response = await Client.PostAsync("/api/CreateTypeUser", default);
        Assert.True(response.StatusCode.Equals(HttpStatusCode.Unauthorized));
    }

	private CreateTypeUserRequest GetCreateTypeUserRequest()
	{
		return new CreateTypeUserRequest
		{
			TypeUser = new TypeUser {
				Id = Guid.NewGuid(),
				Name = "Student"
			}
		};
	}
}

