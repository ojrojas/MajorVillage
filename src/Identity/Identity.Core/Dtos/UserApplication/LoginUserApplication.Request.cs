namespace Identity.Core.Dtos;
public record LoginUserApplicationRequest : BaseRequest 
{
    [Required]
    [EmailAddress]
    public string UserName { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    public string? ClientId { get; set; } 
    public string? ReturnUrl { get; set; } 
    public IEnumerable<string>? Scopes { get; set; } 
}

