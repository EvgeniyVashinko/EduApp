using System;

namespace EduApp.Core.Requests.Homework
{
    public class UpdateHomeworkRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LessonId { get; set; }
        public string Answer { get; set; }
        public string Url { get; set; }
        public int Mark { get; set; }
    }
}
