namespace School.Core.Dtos;

public record CreateStudentRequest: BaseRequest
{
    public Student Student { get; set; }
}

public record CreateStudentResponse: BaseResponse
{
    public CreateStudentResponse(Guid correlationId): base(correlationId)  { }
    public Student StudentCreated { get; set; }
}

public record UpdateStudentRequest: BaseRequest
{
    public Student Student { get; set; }
}

public record UpdateStudentResponse: BaseResponse
{
    public UpdateStudentResponse(Guid correlationId): base(correlationId) {}
    public Student StudentUpdated { get; set; }
}

public record DeleteStudentRequest: BaseRequest
{
    public Guid Id { get; set; }
}

public record DeleteStudentResponse: BaseResponse
{
    public DeleteStudentResponse(Guid correlationId): base(correlationId) { }
    public bool IsStudentDeleted { get; set; }
}

public record GetStudentByIdRequest: BaseRequest
{
    public Guid Id { get; set; }
}

public record GetStudentByIdResponse: BaseResponse
{
    public GetStudentByIdResponse(Guid correlationId): base(correlationId) { }
    public Student Student { get; set; }
}

public record GetAllStudentsRequest : BaseRequest { }

public record GetAllStudentsResponse : BaseResponse
{
    public GetAllStudentsResponse(Guid correlationId): base(correlationId) { }
    public IEnumerable<Student> Students { get; set; }
}