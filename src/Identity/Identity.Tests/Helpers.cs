namespace Identity.Tests;

	public static class Helpers
	{

    public static async ValueTask<string> GetToken(HttpClient Client)
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

    public static JsonSerializerSettings _serializeSettings = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        NullValueHandling = NullValueHandling.Ignore
    };

}

