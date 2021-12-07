using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class CourseCategory : BaseEntity<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
