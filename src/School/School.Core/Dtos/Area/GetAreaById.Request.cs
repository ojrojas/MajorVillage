namespace School.Core.Dtos;

public record GetAreaByIdRequest: BaseRequest
{
    public Guid Id { get; set; }
}