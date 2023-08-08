namespace School.Core.Dtos;

public record CreatePeriodRequest : BaseRequest
{
    public Period Period { get; set; }
}

public record CreatePeriodResponse : BaseResponse
{
    public CreatePeriodResponse(Guid correlationId) : base(correlationId) { }
    public Period PeriodCreated { get; set; }
}

public record UpdatePeriodRequest : BaseRequest
{
    public Period Period { get; set; }
}

public record UpdatePeriodResponse : BaseResponse
{
    public UpdatePeriodResponse(Guid correlationId) : base(correlationId) { }
    public Period PeriodUpdated { get; set; }
}

public record DeletePeriodRequest : BaseRequest
{
    public Guid Id { get; set; }
}

public record DeletePeriodResponse : BaseResponse
{
    public DeletePeriodResponse(Guid correlationId) : base(correlationId) { }
    public bool IsPeriodDeleted { get; set; }
}

public record GetPeriodByIdRequest : BaseRequest
{
    public Guid Id { get; set; }
}

public record GetPeriodByIdResponse : BaseResponse
{
    public GetPeriodByIdResponse(Guid correlationId) : base(correlationId) { }
    public Period Period { get; set; }
}

public record GetAllPeriodsRequest : BaseRequest { }

public record GetAllPeriodsResponse : BaseResponse
{
    public GetAllPeriodsResponse(Guid correlationId) : base(correlationId) { }
    public IEnumerable<Period> Periods { get; set; }
}