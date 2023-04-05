
namespace Identity.Core.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set;}
    public DateTime CreatedDate { get; set;}
    public DateTime UpdatedDate { get; set;}
    public bool State { get; set; }
}
