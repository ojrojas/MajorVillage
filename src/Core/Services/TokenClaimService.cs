namespace MajorVillage.Core.Services;

public class TokenClaimService : ITokenClaimService
{
    private readonly IConfiguration _configuration;

    public TokenClaimService(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<string> GetTokenAsync(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretPhrase"]);
        var claims = new List<Claim>();

        foreach (PropertyInfo prop in user.GetType().GetProperties())
        {
            _ = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            if (prop.Name != "Password")
                if (prop.GetValue(user, null) != null)
                    claims.Add(new Claim(prop.Name, prop.GetValue(user, null).ToString()));
        }

        await Task.CompletedTask;

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}