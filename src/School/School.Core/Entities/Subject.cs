namespace School.Core.Entities;

public class Subject: BaseEntity, IAggregateRoot
{
	[Required]
	public string? Name { get; set; }
	[Required]
	public Guid AreaId { get; set; }
	public Area? Area { get; set; }
}