using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }

        public Guid LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }
}
