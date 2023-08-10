using System;
namespace Identity.Tests.Core.Services;

public class GetUserApplicationByIdTest: IClassFixture<IdentityApiFactory>
{
	private readonly HttpClient Client;

	public GetUserApplicationByIdTest(IdentityApiFactory factory)
	{
		Client = factory.CreateClient();
	}

	[Fact]
	public async Task Get_UserApplication_By_Id_Should_Success_OK()
	{
        //arrange
        CreateUserApplicationRequest request = new() { UserApplication = GetCreateUserApplication() };
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(Client));
       
        StringContent content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/CreateUserApplication", content);
        response.EnsureSuccessStatusCode();
        //act
        request.UserApplication.Name = "UPDATEUPDATE";
        request.UserApplication.BirthDate = new DateTime(2020, 11, 18);
        var response2 = await Client.PatchAsync("/api/UpdateUserApplication", content);
        response2.EnsureSuccessStatusCode();
        var stringResponse = await response2.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<CreateUserApplicationResponse>(stringResponse, Helpers._serializeSettings);

        //assert
        Assert.NotNull(model);
        Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));
        Assert.True(response2.StatusCode.Equals(HttpStatusCode.OK));
    }

    private ApplicationUser GetCreateUserApplication()
    {
        return new ApplicationUser
        {
            Id = Guid.NewGuid(),
            Name = "Test1",
            LastName = "Test1",
            UserName = "TEST@TEST.COM",
            PasswordHash = "Abc123456#",
            Identification = "TESTTESTTEST",
            BirthDate = new DateTime(2000, 12, 1),
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
            }
        };
    }
}

