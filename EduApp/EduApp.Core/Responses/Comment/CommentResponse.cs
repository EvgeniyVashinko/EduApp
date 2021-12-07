using System;

namespace EduApp.Core.Responses.Comment
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid LessonId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public CommentResponse()
        {
        }

        public CommentResponse(Entities.Comment comment)
        {
            Id = comment.Id;
            AccountId = comment.AccountId;
            LessonId = comment.LessonId;
            Text = comment.Text;
            CreationDate = comment.CreationDate;
            UpdatedDate = comment.UpdatedDate;
        }
    }
}
