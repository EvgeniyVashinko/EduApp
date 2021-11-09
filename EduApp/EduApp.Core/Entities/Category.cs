using EduApp.Core.Common;
using System;
using System.Collections.Generic;

namespace EduApp.Core.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
