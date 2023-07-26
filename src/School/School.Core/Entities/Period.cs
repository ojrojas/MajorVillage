namespace School.Core.Entities;

public class Period: BaseEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public PeriodStatus PeriodStatus { get; set; }
}

public enum PeriodStatus
{
    Starter = 1,
    Endend,
    Cancelled,
    Aborted,
}

