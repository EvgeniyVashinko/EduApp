using EduApp.Core.Common;
using System;
using System.Collections.Generic;

namespace EduApp.Core.Entities
{
    public class Lesson : BaseEntity<Guid>
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        public string ExternalLink { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
