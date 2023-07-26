
namespace School.Core.Entities;

public class ClassRoom : BaseEntity, IAggregateRoot
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public ClassRoomStatus ClassRoomStatus { get; set; }
    [Required]
    public string? Located { get; set; }
}

public enum ClassRoomStatus
{
    Free = 0,
    Avaliable,
    Busy,
    Closed,
    InReparation
}

