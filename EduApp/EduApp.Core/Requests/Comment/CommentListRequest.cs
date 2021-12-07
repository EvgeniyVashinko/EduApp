using System;

namespace EduApp.Core.Requests.Comment
{
    public class CommentListRequest
    {
        public Guid AccountId { get; set; }
        public Guid LessonId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
