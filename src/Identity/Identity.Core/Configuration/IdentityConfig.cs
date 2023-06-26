namespace Identity.Core.Configuration;

public static class IdentityConfig
{
    public static IEnumerable<ApiResource> GetApis()
    {
        return new List<ApiResource>
        {
            new ApiResource("school", "School Resource Api"),
            new ApiResource("notesandmaths", "Note and Maths Api")
        };
    }

    public static IEnumerable<IdentityResource> GetResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }

    public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrls)
    {
        return new List<Client>
        {
            new Client()
            {
                ClientId ="schoolclientswaggerui",
                ClientName = "Client To School",
                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,

                RedirectUris = { $"{clientsUrls["SchoolApiClient"]}/swagger/oauth2-redirect.html"},
                PostLogoutRedirectUris = { $"{clientsUrls["SchoolApiClient"]}/swagger" },

                AllowedScopes = {
                   "school"
                }
            }
        };
    }
}

