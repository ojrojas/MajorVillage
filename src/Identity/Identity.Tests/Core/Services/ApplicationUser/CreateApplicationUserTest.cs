namespace Identity.Tests.Core.Services;

public class CreateApplicationUserTest: IClassFixture<IdentityApiFactory>
{
    private readonly HttpClient Client;

	public CreateApplicationUserTest(IdentityApiFactory factory)
	{
        Client = factory.CreateClient();
	}

    [Fact]
    public async Task Create_ApplicationUser_Should_Success_OK()
    {
        //arrange
        CreateUserApplicationRequest request = new() { UserApplication = GetCreateUserApplication() };
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
        //act
        StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateUserApplication", content);
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<CreateUserApplicationResponse>(stringResponse, Helpers._serializeSettings);

        //assert
        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.NotNull(model);
    }

    [Fact]
    public async Task Create_ApplicationUser_Should_UnAuthorize()
    {
        //arrange
        CreateUserApplicationRequest request = new() { UserApplication = GetCreateUserApplication() };
        //act
        StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateUserApplication", content);
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<CreateUserApplicationResponse>(stringResponse, Helpers._serializeSettings);

        //assert
        Assert.True(response.StatusCode.Equals(HttpStatusCode.Unauthorized));
        Assert.Null(model);
    }

    private ApplicationUser GetCreateUserApplication()
    {
        return new ApplicationUser
        {
            Name = "Test1",
            LastName = "Test1",
            UserName = "TEST@TEST.COM",
            PasswordHash = "Abc123456#",
            Identification = "TESTTESTTEST",
            BirthDate = new DateTime(2000,12,1),
            Address = "TESTTEST",
            Contact = "TESTTEST",
            TypeIdentification = new TypeIdentification
            {
                Name = "TEST1",
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow
            },
            TypeUser = new TypeUser
            {
                Id = Guid.NewGuid(),
                Name = "TEST1",
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow
            }
        };
    }
}

