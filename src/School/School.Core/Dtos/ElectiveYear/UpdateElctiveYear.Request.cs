namespace School.Core.Dtos;

public record UpdateElctiveYearRequest: BaseRequest
{
    public ElectiveYear ElectiveYear { get; set; }
}

