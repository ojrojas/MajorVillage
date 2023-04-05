namespace Identity.Core.Dtos;

public record GetUserByIdRequest : BaseRequest
{
	public Guid Id { get; set; }
}

