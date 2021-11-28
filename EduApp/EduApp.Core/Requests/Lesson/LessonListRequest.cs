using System;

namespace EduApp.Core.Requests.Lesson
{
    public class LessonListRequest
    {
        public string Title { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
