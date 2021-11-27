using System;

namespace EduApp.Core.Responses.Course
{
    public class CourseResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public CourseResponse()
        {
        }

        public CourseResponse(Entities.Course course)
        {
            Id = course.Id;
            AccountId = course.OwnerId;
            Title = course.Title;
            Description = course.Description;
            Price = course.Price;
            CreationDate = course.CreationDate;
            UpdatedDate = course.UpdatedDate;
        }
    }
}
