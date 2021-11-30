using EduApp.Core.Common;
using System;
using System.Collections.Generic;

namespace EduApp.Core.Entities
{
    public class Homework : BaseEntity<Guid>
    {
        public string Answer { get; set; }

        public string Url { get; set; }

        public byte Mark { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }

        public Guid LessonId { get; set; }

        public Lesson Lesson { get; set; }
    }
}
