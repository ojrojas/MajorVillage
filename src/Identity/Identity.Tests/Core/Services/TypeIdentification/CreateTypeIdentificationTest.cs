using System.Net;
using System.Net.Http.Headers;
using Azure.Core;
using OpenIddict.Client;

namespace Tests.Core.Services;

public class CreateTypeIdentificationTest
{
    private readonly IdentityApiFactory _application;
    private readonly HttpClient Client;
    private readonly OpenIddictClientService _authenticateCredentials;
    private readonly JsonSerializerSettings _serializeSettings = new JsonSerializerSettings()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        NullValueHandling = NullValueHandling.Ignore
    };

    public CreateTypeIdentificationTest()
    {
        _application = new IdentityApiFactory("Testing");
        var logger = LoggerFactory.Create(factory => factory.AddConsole());
        Client = _application.CreateClient();
    }

    [Fact]
    public async Task Create_TypeIdentification_Success()
    {
        //Arrange
        // dtos
        CreateTypeIdentificationRequest request = GetTypeIdentificationRequestFake();

        //Act
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
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
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
        var response = await Client.PostAsync("/api/CreateTypeIdentification", default);
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<CreateTypeIdentificationResponse>(stringResponse, _serializeSettings);
        Assert.Null(model);
    }

    private async ValueTask<string> GetToken()
    {
        try
        {
            var request = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("scope", "identity"),
                new KeyValuePair<string, string>("client_id", "identityswaggeruitesting"),
                new KeyValuePair<string, string>("client_secret", "187b02a3-7611-4a05-974c-3337655d169b")
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(request);
            var response = await Client.PostAsync("/connect/token", content);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<TokenResponse>(stringResponse, _serializeSettings);
            return model.Access_Token;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
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

