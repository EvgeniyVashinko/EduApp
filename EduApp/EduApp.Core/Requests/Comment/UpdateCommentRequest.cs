using System;

namespace EduApp.Core.Requests.Comment
{
    public class UpdateCommentRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LessonId { get; set; }
        public string Text { get; set; }
    }
}
