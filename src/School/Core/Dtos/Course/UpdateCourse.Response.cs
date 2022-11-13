namespace Core.Dtos
{
    public class UpdateCourseResponse: BaseResponse
    {
        public UpdateCourseResponse(Guid correlationId) : base(correlationId)
        {
        }

        public Course CourseUpdated { get; set; }
    }
}
