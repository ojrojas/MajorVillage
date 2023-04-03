namespace Core.Dtos;

public record CreateTypeIdentificationRequest : BaseRequest
{
    public TypeIdentification TypeIdentification { get; set; }
}

