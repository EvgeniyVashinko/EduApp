using System;

namespace EduApp.Core.Requests.Lesson
{
    public class CreateLessonRequest
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RecommendedTime { get; set; }
    }
}
