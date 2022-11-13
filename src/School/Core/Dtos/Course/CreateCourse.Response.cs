namespace Core.Dtos
{
    public class CreateCourseResponse : BaseResponse
    {
        public CreateCourseResponse(Guid correlationId) : base(correlationId)
        {
        }

        public Course CourseCreated { get; set; }
    }
}
