using System;

namespace EduApp.Core.Requests.Course
{
    public class CreateCourseRequest
    {
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
    }
}
