namespace Identity.Core.Dtos;

public record CreateAttendantRequest: BaseRequest
{
    public Attendant Attendant { get; set; }
}

