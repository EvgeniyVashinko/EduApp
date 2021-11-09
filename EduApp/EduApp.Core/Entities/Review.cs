using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class Review : BaseEntity<Guid>
    {
        public byte Value { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }
    }
}
