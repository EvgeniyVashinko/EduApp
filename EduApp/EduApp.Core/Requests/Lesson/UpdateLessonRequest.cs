using System;

namespace EduApp.Core.Requests.Lesson
{
    public class UpdateLessonRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExternalLink { get; set; }
    }
}
