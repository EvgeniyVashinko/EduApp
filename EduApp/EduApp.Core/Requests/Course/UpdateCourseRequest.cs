using System;

namespace EduApp.Core.Requests.Course
{
    public class UpdateCourseRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
