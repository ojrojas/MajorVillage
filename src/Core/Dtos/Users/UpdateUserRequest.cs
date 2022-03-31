namespace MajorVillage.Core.Dtos;

public class UpdateUserRequest : BaseResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string SurName { get; set; } = string.Empty;
    public Guid ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
}