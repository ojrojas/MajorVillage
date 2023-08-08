namespace School.Core.Dtos;

public record CreateSubjectRequest : BaseRequest
{
    public Subject Subject { get; set; }
}

public record CreateSubjectResponse : BaseResponse
{
    public CreateSubjectResponse(Guid correlationId) : base(correlationId) { }
    public Subject SubjectCreated { get; set; }
}

public record UpdateSubjectRequest : BaseRequest
{
    public Subject Subject { get; set; }
}

public record UpdateSubjectResponse : BaseResponse
{
    public UpdateSubjectResponse(Guid correlationId) : base(correlationId) { }
    public Subject SubjectUpdated { get; set; }
}

public record DeleteSubjectRequest : BaseRequest
{
    public Guid Id { get; set; }
}

public record DeleteSubjectResponse : BaseResponse
{
    public DeleteSubjectResponse(Guid correlationId) : base(correlationId) { }
    public bool IsSubjectDeleted { get; set; }
}

public record GetSubjectByIdRequest : BaseRequest
{
    public Guid Id { get; set; }
}

public record GetSubjectByIdResponse : BaseResponse
{
    public GetSubjectByIdResponse(Guid correlationId) : base(correlationId) { }
    public Subject Subject { get; set; }
}

public record GetAllSubjectsRequest : BaseRequest { }

public record GetAllSubjectsResponse : BaseResponse
{
    public GetAllSubjectsResponse(Guid correlationId) : base(correlationId) { }
    public IEnumerable<Subject> Subjects { get; set; }
}