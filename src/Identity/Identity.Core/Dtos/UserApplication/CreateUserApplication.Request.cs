namespace Identity.Core.Dtos;

public record CreateUserApplicationRequest : BaseRequest
{
    public ApplicationUser UserApplication { get; set; }
}

