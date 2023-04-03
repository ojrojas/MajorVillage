namespace Core.Dtos;

public record UpdateTypeIdentificationRequest : BaseRequest
{
    public TypeIdentification TypeIdentification { get; set; }
}

