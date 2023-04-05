namespace Identity.Core.Dtos;

public record UpdateAttendantRequest : BaseRequest
{
    public Attendant Attendant { get; set; }
}

