using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class CourseParticipants : BaseEntity<Guid>
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
