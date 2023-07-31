namespace Identity.Core.Dtos;

public record UpdateUserApplicationRequest: BaseRequest
{
    public ApplicationUser? UserApplication { get; set; }
}

