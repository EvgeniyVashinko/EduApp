using EduApp.Core.Common;
using System;

namespace EduApp.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime RecommendedTime { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }
    }
}
