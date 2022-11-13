namespace Core.Dtos
{
    public class GetAllCourseResponse : BaseResponse
    {
        public GetAllCourseResponse(Guid correlationId) : base(correlationId)
        {
        }

        public IEnumerable<Course> Courses { get; set; }
    }
}
