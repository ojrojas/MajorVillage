namespace Identity.Tests.Core.Services;

public class UpdateTypeUserTest : IClassFixture<IdentityApiFactory>
{
	private readonly HttpClient Client;

	public UpdateTypeUserTest(IdentityApiFactory factory)
	{
		Client = factory.CreateClient();
	}

	[Fact]
	public async Task Update_TypeUser_Should_Success_OK()
	{
		//arrange
		CreateTypeUserRequest request = GetCreateTypeUserRequest();
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateTypeUser", content);
        response.EnsureSuccessStatusCode();

        //act
        request.TypeUser.Name = "TESTUPDATE";
        StringContent content2 = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response2 = await Client.PatchAsync("/api/UpdateTypeUser", content2);
        response2.EnsureSuccessStatusCode();

        //assert
        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.True(response2.StatusCode.Equals(HttpStatusCode.OK));
    }

    [Fact]
    public async Task Update_TypeUser_Should_UnAuthorize()
    {
        //arrange
        CreateTypeUserRequest request = GetCreateTypeUserRequest();

        //act
        StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateTypeUser", content);

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

