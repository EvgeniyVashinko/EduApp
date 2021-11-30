using System;

namespace EduApp.Core.Requests.Homework
{
    public class HomeworkListRequest
    {
        public Guid AccountId { get; set; }
        public Guid LessonId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
