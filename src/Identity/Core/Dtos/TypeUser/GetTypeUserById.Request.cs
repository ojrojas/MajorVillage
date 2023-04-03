namespace Core.Dtos;

public record GetTypeUserByIdRequest : BaseRequest
{
	public Guid Id { get; set; }
}

