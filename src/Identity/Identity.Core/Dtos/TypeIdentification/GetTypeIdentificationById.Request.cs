namespace Identity.Core.Dtos;

public record GetTypeIdentificationByIdRequest : BaseRequest
{
	public Guid Id { get; set; }
}

