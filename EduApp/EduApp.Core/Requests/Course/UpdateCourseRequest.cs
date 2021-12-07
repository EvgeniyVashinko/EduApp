using System;
using System.Collections.Generic;

namespace EduApp.Core.Requests.Course
{
    public class UpdateCourseRequest
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public List<Guid> Categories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
